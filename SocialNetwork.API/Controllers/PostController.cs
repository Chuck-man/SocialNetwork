using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.DTO;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Repository;

namespace SocialNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController(IRepository<Post> repository, IMapper mapper) : Controller
{
    [HttpGet]
    public ActionResult<IEnumerable<PostFullDto>> Get()
    {
        return Ok(repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<PostFullDto> Get(int id)
    {
        var classValue = repository.GetById(id);

        if (classValue == null)
            return NotFound();
        return Ok(classValue);
    }

    [HttpPost]
    public ActionResult<PostFullDto> Post([FromBody] PostDto value)
    {
        var post = mapper.Map<Post>(value);
        return mapper.Map<PostFullDto>(repository.Post(post));
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] PostDto value)
    {
        var post = mapper.Map<Post>(value);
        return Ok(repository.Put(id, post));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();

        return Ok();
    }
}
