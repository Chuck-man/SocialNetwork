using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.DTO;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Repository;

namespace SocialNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController(IRepository<Comment> repository, IMapper mapper) : Controller
{
    [HttpGet]
    public ActionResult<IEnumerable<CommentFullDto>> Get()
    {
        return Ok(repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<CommentFullDto> Get(int id)
    {
        var classValue = repository.GetById(id);

        if (classValue == null)
            return NotFound();
        return Ok(classValue);
    }

    [HttpPost]
    public ActionResult<CommentFullDto> Post([FromBody] CommentDto value)
    {
        var comment = mapper.Map<Comment>(value);
        return mapper.Map<CommentFullDto>(repository.Post(comment));
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] CommentDto value)
    {
        var comment = mapper.Map<Comment>(value);
        return Ok(repository.Put(id, comment));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();

        return Ok();
    }
}
