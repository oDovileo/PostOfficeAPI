using Microsoft.AspNetCore.Mvc;
using PostOfficeAPI.Dtos;
using PostOfficeAPI.Services;
using System.Threading.Tasks;

namespace PostOfficeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelController : ControllerBase
    {
        private readonly ParcelService _parcelService;

        public ParcelController(ParcelService parcelService)
        {
            _parcelService = parcelService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _parcelService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var parcel = await _parcelService.GetByIdAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }
            return Ok(parcel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateParcelDto bettor)
        {

            return Ok(await _parcelService.AddAsync(bettor));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _parcelService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateParcelDto parsel)
        {
            await _parcelService.UpdateAsync(parsel);
            return NoContent();
        }
        //[HttpGet("Post/{id}")]
        //public async Task<ActionResult> FilterByPostId(int id)
        //{
        //    return Ok(await _parcelService.FilterByPostId(id));
        //}
    }
}
