using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.DTO;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Repository;

namespace SocialNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController(IRepository<Member> repository, IMapper mapper) : Controller
{
    [HttpGet]
    public ActionResult<IEnumerable<MemberFullDto>> Get()
    {
        return Ok(repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<MemberFullDto> Get(int id)
    {
        var classValue = repository.GetById(id);

        if (classValue == null)
            return NotFound();
        return Ok(classValue);
    }

    [HttpPost]
    public ActionResult<MemberFullDto> Post([FromBody] MemberDto value)
    {
        var member = mapper.Map<Member>(value);
        return mapper.Map<MemberFullDto>(repository.Post(member));
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] MemberDto value)
    {
        var member = mapper.Map<Member>(value);
        return Ok(repository.Put(id, member));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();

        return Ok();
    }
}
