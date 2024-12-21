using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.DTO;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Repository;

namespace SocialNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController(IRepository<Role> repository, IMapper mapper) : Controller
{
    [HttpGet]
    public ActionResult<IEnumerable<RoleFullDto>> Get()
    {
        return Ok(repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<RoleFullDto> Get(int id)
    {
        var classValue = repository.GetById(id);

        if (classValue == null)
            return NotFound();
        return Ok(classValue);
    }

    [HttpPost]
    public ActionResult<RoleFullDto> Post([FromBody] RoleDto value)
    {
        var role = mapper.Map<Role>(value);
        return mapper.Map<RoleFullDto>(repository.Post(role));
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] RoleDto value)
    {
        var role = mapper.Map<Role>(value);
        return Ok(repository.Put(id, role));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();

        return Ok();
    }
}
