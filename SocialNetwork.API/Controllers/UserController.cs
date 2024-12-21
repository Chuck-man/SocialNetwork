using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.Repository;
using SocialNetwork.Domain.Entities;
using SocialNetwork.API.DTO;

namespace SocialNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IRepository<User> repository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<UserFullDto>> Get()
    {
        return Ok(repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<UserFullDto> Get(int id)
    {
        var classValue = repository.GetById(id);

        if (classValue == null)
            return NotFound();

        return Ok(classValue);
    }

    [HttpPost]
    public ActionResult<UserFullDto> Post([FromBody] UserDto value)
    {
        var user = mapper.Map<User>(value);
        return mapper.Map<UserFullDto>(repository.Post(user));
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] UserDto value)
    {
        var user = mapper.Map<User>(value);
        return Ok(repository.Put(id, user));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();

        return Ok();
    }
}
