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
        [LogFilter]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroups([FromQuery] string? name = null, [FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            try
            {
                var groups = await service.GetGroups(name, skip, take);
                return Ok(mapper.Map<IEnumerable<GroupDTO>>(groups));
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDTO>> GetGroupById([FromRoute] Guid id)
        {
            try
            {
                var group = await service.GetGroupById(id);
                if (group == null)
                    throw new ArgumentException("Such group doesn't exist");
                return Ok(mapper.Map<GroupDTO>(group));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGroup([FromRoute] Guid id)
        {
            try
            {
                await service.DeleteGroup(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<GroupDTO>> AddGroup([FromBody] CreateGroupDTO createGroupDto)
        {
            try
            {
                var group = await service.AddGroup(mapper.Map<Group>(createGroupDto));
                return Created($"groups/{group.Id}",mapper.Map<GroupDTO>(group));
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("add_student/{studentId}/to_group/{groupId}")]
        public async Task<ActionResult> AddStudentToGroup([FromRoute] Guid groupId, [FromRoute] Guid studentId)
        {
            try
            {
                await service.AddStudentToGroup(groupId, studentId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
