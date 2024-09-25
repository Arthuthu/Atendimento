using AtendimentoApi.Dtos.Request;
using AtendimentoApplication.Abstractions.Application;
using AtendimentoDomain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtendimentoApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost, AllowAnonymous, Route("/login")]
        [ProducesResponseType(typeof(string), 200),
        ProducesResponseType(404)]
        public async Task<IActionResult> Login([FromForm] AuthRequest authRequest,
            CancellationToken cancellationToken)
        {
            User user = _mapper.Map<AuthRequest, User>(authRequest);
            string? loginResult = await _authService.Login(user, cancellationToken);

            if (loginResult is null)
                return NotFound("Usuario ou senha incorretos");

            var output = new { Access_Token = loginResult };

            return Ok(output);
        }
    }
}
