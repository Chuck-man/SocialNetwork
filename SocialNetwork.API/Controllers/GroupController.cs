using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.DTO;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Repository;

namespace SocialNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController(IRepository<Group> repository, IMapper mapper) : Controller
{
    [HttpGet]
    public ActionResult<IEnumerable<GroupFullDto>> Get()
    {
        return Ok(repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<GroupFullDto> Get(int id)
    {
        var classValue = repository.GetById(id);

        if (classValue == null)
            return NotFound();
        return Ok(classValue);
    }

    [HttpPost]
    public ActionResult<GroupFullDto> Post([FromBody] GroupDto value)
    {
        var group = mapper.Map<Group>(value);
        return mapper.Map<GroupFullDto>(repository.Post(group));
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] GroupDto value)
    {
        var group = mapper.Map<Group>(value);
        return Ok(repository.Put(id, group));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();

        return Ok();
    }
}
