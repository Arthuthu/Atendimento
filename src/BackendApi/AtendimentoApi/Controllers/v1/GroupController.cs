using AtendimentoApi.Dtos.Request;
using AtendimentoApi.Dtos.Response;
using AtendimentoApplication.Abstractions.Application;
using AtendimentoDomain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AtendimentoApi.Controllers.v1
{
    public class GroupController : Controller
    {
        private readonly IGroupService _service;
        private readonly IMapper _mapper;

        public GroupController(IGroupService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("v1/group/add")]
        [ProducesResponseType(typeof(string), 400),
         ProducesResponseType(500)]
        public async Task<IActionResult> Add([FromBody] GroupRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Group group = _mapper.Map<Group>(request);
                string? resultado = await _service.Add(group, cancellationToken);

                if (resultado is not null)
                {
                    return BadRequest(resultado);
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error ocurred while adding the group {ex.Message}");
            }
        }

        [HttpPut]
        [Route("v1/group/update")]
        [ProducesResponseType(typeof(GroupResponse), 200),
        ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromBody] GroupRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Group group = _mapper.Map<Group>(request);
                Group? requestedGroup = await _service.Update(group, cancellationToken);

                if (requestedGroup is null)
                {
                    return NotFound("Group was not found for update");
                }

                return Ok(_mapper.Map<GroupResponse>(group));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error ocurred while updating the group {ex.Message}");
            }
        }

        [HttpGet]
        [Route("v1/group/get/{id}")]
        [ProducesResponseType(typeof(GroupResponse), 200),
         ProducesResponseType(404), ProducesResponseType(500)]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Group? group = await _service.GetGroupById(id, cancellationToken);

                if (group is null)
                {
                    return NotFound("Group not found");
                }

                return Ok(_mapper.Map<Group>(group));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error has occurred while searching for the group: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("v1/group/delete/{id}")]
        [ProducesResponseType(200),
         ProducesResponseType(404), ProducesResponseType(500)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                bool result = await _service.Delete(id, cancellationToken);

                if (result is false)
                {
                    return NotFound("Group was not deleted, because it was not found");
                }

                return Ok("Group has been successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error has occurred while deleting the group: {ex.Message}");
            }
        }
    }
}
