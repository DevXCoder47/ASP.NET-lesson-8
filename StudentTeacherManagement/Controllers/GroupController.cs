using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTeacherManagement.Core.Interfaces;
using StudentTeacherManagement.Core.Models;
using StudentTeacherManagement.DTOs;

namespace StudentTeacherManagement.Controllers
{
    [Route("groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService service;
        private readonly IMapper mapper;
        public GroupController(IGroupService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroups([FromQuery] string? name = null,
            [FromQuery] int skip = 0,
            [FromQuery] int take = 10)
        {
            var groups = await service.GetGroups(name, skip, take);
            return Ok(mapper.Map<IEnumerable<GroupDTO>>(groups));
        }
    }
}
