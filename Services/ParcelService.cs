using PostOfficeAPI.Dtos;
using PostOfficeAPI.Entities;
using PostOfficeAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostOfficeAPI.Services
{
    public class ParcelService
    {
        private ParcelRepository _parcelRepository;
        private PostRepository _postRepository;
        public ParcelService(ParcelRepository parcelRepository, PostRepository postRepository)
        {
            _parcelRepository = parcelRepository;
            _postRepository = postRepository;
        }
        public async Task<List<UpdateParcelDto>> GetAllAsync()
        {
            List<ParcelModel> parcels = await _parcelRepository.GetAsync();
            List<PostModel> posts = await _postRepository.GetAllAsync();
            var dtos = parcels.Select(p => new UpdateParcelDto
            {
                Id = p.Id,
                NameSurname = p.NameSurname,
                Weight = p.Weight,
                Phone = p.Phone,
                PostId = p.PostId != null ? p.PostId : null,
                PostTown = p.PostId == null ? "" : posts.FirstOrDefault(I => I.Id == p.PostId).Town.ToString()
            });

            return dtos.ToList();
        }

        public async Task<ParcelModel> GetByIdAsync(int id)
        {
            var parcel = await _parcelRepository.GetByIdAsync(id);
            if (parcel == null)
            {
                throw new ArgumentException($"Id {id} does not exist.");
            }
            return parcel;
        }

        public async Task<ParcelDto> AddAsync(CreateParcelDto createParcelDto)
        {
            var entity = new ParcelModel
            {
                NameSurname = createParcelDto.NameSurname,
                Weight = createParcelDto.Weight,
                Phone = createParcelDto.Phone,
                PostId = createParcelDto.PostId
            };


            if (createParcelDto.PostId.HasValue)
            {
                var parcel = await _postRepository.GetByIdAsync(createParcelDto.PostId.Value);
                if (parcel == null)
                {
                    throw new ArgumentException("Parcel does not exist");
                }
            }

            ParcelModel newParcel = await _parcelRepository.AddAsync(entity);

            PostModel post = await _postRepository.GetByIdAsync((int)newParcel.PostId);
            string postTown = post.Town;

            ParcelDto parcelDto = new()
            {
                Id = entity.Id,
                NameSurname = entity.NameSurname,
                Weight = entity.Weight,
                PostId = entity.PostId,
                PostTown = postTown
            };

            return parcelDto;
        }

        public async Task DeleteAsync(int id)
        {
            var parcel = await GetByIdAsync(id);
            if (parcel == null)
            {
                throw new ArgumentException($"Id {id} does not exist.");
            }
            await _parcelRepository.DeleteAsync(parcel);
        }

        public async Task<ParcelDto> UpdateAsync(UpdateParcelDto updateParcelDto)
        {
            var parsel = await _parcelRepository.GetByIdAsync(updateParcelDto.Id);
            if (parsel == null)
            {
                throw new ArgumentException($"Id {updateParcelDto.Id} does not exist.");
            }

            parsel.Id = updateParcelDto.Id;
            parsel.NameSurname = updateParcelDto.NameSurname;
            parsel.Phone = updateParcelDto.Phone;
            parsel.Weight = updateParcelDto.Weight;
            parsel.PostId = updateParcelDto.PostId;

            await _parcelRepository.UpdateAsync(parsel);

            PostModel post = await _postRepository.GetByIdAsync((int)updateParcelDto.PostId);
            string postTown = post.Town;

            ParcelDto parcel = new()
            {
                Id = updateParcelDto.Id,
                NameSurname = updateParcelDto.NameSurname,
                Phone = updateParcelDto.Phone,
                Weight = updateParcelDto.Weight,
                PostId = updateParcelDto.PostId,
                PostTown = postTown
            };

            return parcel;
        }
        //public async Task<List<ParcelDto>> FilterByPostId(int id)
        //{
        //    if (id != 0)
        //    {
        //        List<ParcelModel> filteredParcels = await _parcelRepository.FilterByPostId(id);
        //        List<ParcelDto> parcelDtos = new();
        //    }
        //}
    }
}
