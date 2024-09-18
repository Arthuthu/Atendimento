using AtendimentoApi.Dtos.Request;
using AtendimentoApi.Dtos.Response;
using AtendimentoApplication.Abstractions.Application;
using AtendimentoDomain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AtendimentoApi.Controllers.v1
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("v1/user/add")]
        [ProducesResponseType(typeof(string), 400),
         ProducesResponseType(500)]
        public async Task<IActionResult> Add([FromBody] UserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                User user = _mapper.Map<User>(request);
                string? resultado = await _service.Add(user, cancellationToken);

                if (resultado is not null)
                {
                    return BadRequest(resultado);
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error ocurred while adding the user {ex.Message}");
            }
        }

        [HttpPut]
        [Route("v1/user/update")]
        [ProducesResponseType(typeof(UserResponse), 200),
        ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromBody] UserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                User user = _mapper.Map<User>(request);
                User? requestedUser = await _service.Update(user, cancellationToken);

                if (requestedUser is null)
                {
                    return NotFound("User was not found for update");
                }

                return Ok(_mapper.Map<UserResponse>(user));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error ocurred while updating the user {ex.Message}");
            }
        }

        [HttpGet]
        [Route("v1/user/get/{id}")]
        [ProducesResponseType(typeof(UserResponse), 200),
         ProducesResponseType(404), ProducesResponseType(500)]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                User? user = await _service.GetUserById(id, cancellationToken);

                if (user is null)
                {
                    return NotFound("User not found");
                }

                return Ok(_mapper.Map<User>(user));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error has occurred while searching for the user: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("v1/user/delete/{id}")]
        [ProducesResponseType(200),
         ProducesResponseType(404), ProducesResponseType(500)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                bool result = await _service.Delete(id, cancellationToken);

                if (result is false)
                {
                    return NotFound("User was not deleted, because it was not found");
                }

                return Ok("User has been successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error has occurred while deleting the user: {ex.Message}");
            }
        }
    }
}
