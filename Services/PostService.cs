using PostOfficeAPI.Dtos;
using PostOfficeAPI.Entities;
using PostOfficeAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostOfficeAPI.Services
{
    public class PostService
    {
        private PostRepository _postRepository;

        public PostService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<List<PostModel>> GetAllAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<PostModel> GetByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
            {
                throw new ArgumentException("Post not found");
            }
            return post;
        }

        public async Task DeleteAsync(int id)
        {
            var post = await GetByIdAsync(id);
            await _postRepository.DeleteAsync(post);
        }

        public async Task CreateAsync(CreatePostDto createPostDto)
        {
            var entity = new PostModel
            {
                Town = createPostDto.Town,
                Capacity = createPostDto.Capacity,
                Code = createPostDto.Code
            };

            await _postRepository.CreateAsync(entity);
        }

        internal Task UpdateAsync(object updatehorseDto)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UpdatePostDto updatePostDto)
        {
            PostModel entity = new PostModel
            {
                Id = updatePostDto.Id,
                Town = updatePostDto.Town,
                Capacity = updatePostDto.Capacity,
                Code = updatePostDto.Code
            };

            await _postRepository.UpdateAsync(entity);
        }
    }
}
