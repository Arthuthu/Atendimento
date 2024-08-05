using AtendimentoApi.Dtos.Request;
using AtendimentoApi.Dtos.Response;
using AtendimentoApplication.Abstractions.Application;
using AtendimentoDomain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AtendimentoApi.Controllers.v1
{
    public class AtendimentoController : Controller
    {
        private readonly IAtendimentoService _service;
        private readonly IMapper _mapper;

        public AtendimentoController(IAtendimentoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("v1/atendimento/add")]
		[ProducesResponseType(typeof(AtendimentoResponse), 200),
		 ProducesResponseType(500)]
		public async Task<IActionResult> Add([FromBody] AtendimentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Atendimento atendimento = _mapper.Map<Atendimento>(request);
                await _service.Add(atendimento, cancellationToken);

                return Ok(_mapper.Map<AtendimentoResponse>(atendimento));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error ocurred while adding the atendimento {ex.Message}");
            }
        }

        [HttpPut]
        [Route("v1/atendimento/update")]
        [ProducesResponseType(typeof(AtendimentoResponse), 200),
        ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromBody] AtendimentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Atendimento atendimento = _mapper.Map<Atendimento>(request);
                Atendimento? requestedAtendimento = await _service.Update(atendimento, cancellationToken);

                if (requestedAtendimento is null)
                {
                    return NotFound("Atendimento was not found for update");
                }

                return Ok(_mapper.Map<AtendimentoResponse>(atendimento));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error ocurred while updating the atendimento {ex.Message}");
            }
        }

        [HttpGet]
        [Route("v1/atendimento/get/{id}")]
		[ProducesResponseType(typeof(AtendimentoResponse),200),
		 ProducesResponseType(404), ProducesResponseType(500)]
		public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Atendimento? atendimento = await _service.GetAtendimentoById(id, cancellationToken);

                if (atendimento is null)
                {
                    return NotFound("Atendimento not found");
                }

                return Ok(_mapper.Map<AtendimentoResponse>(atendimento));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"An error has occurred while searching for the atendimento: {ex.Message}");
            }
        }

        public async Task<IActionResult> GetAtendimentosByUserId(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                List<Atendimento>? atendimentos = await _service.GetAtendimentosByUserId(id, cancellationToken);

                if (atendimentos is null)
                {
                    return NotFound("Atendimentos not found");
                }

                return Ok(_mapper.Map<List<AtendimentoResponse>>(atendimentos));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error has occurred while searching for the atendimentos by user id: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("v1/atendimento/delete/{id}")]
		[ProducesResponseType (200),
		 ProducesResponseType(404), ProducesResponseType(500)]
		public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                bool result = await _service.Delete(id, cancellationToken);

                if (result is false)
                {
                    return NotFound("Atendimento was not deleted, because it was not found");
                }

                return Ok("Atendimento has been successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"An error has occurred while deleting the atendimento: {ex.Message}");
            }
        }
    }
}
