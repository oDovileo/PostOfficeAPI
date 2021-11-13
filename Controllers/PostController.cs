using Microsoft.AspNetCore.Mvc;
using PostOfficeAPI.Dtos;
using PostOfficeAPI.Services;
using System.Threading.Tasks;

namespace PostOfficeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _postService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _postService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostDto createPostDto)
        {
            await _postService.CreateAsync(createPostDto);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePostDto updatePostDto)
        {
            await _postService.UpdateAsync(updatePostDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeleteAsync(id);
            return NoContent();
        }

    }
}
