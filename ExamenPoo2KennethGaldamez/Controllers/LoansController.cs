using ExamenPoo2KennethGaldamez.Dtos.Common;
using ExamenPoo2KennethGaldamez.Dtos.Loans;
using ExamenPoo2KennethGaldamez.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenPoo2KennethGaldamez.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoansService _loansService;

        public LoansController(ILoansService LoansService)
        {
            this._loansService = loansService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<PostDto>>> GetOneById(Guid id)
        {
            var response = await _postsService.GetByIdAsync(id);

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data
            });
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<LoansDto>>> Create(LoanCreateDto dto)
        {
            var response = _loansService.CreateAsync(dto);

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto>LoanDto>>> Edit(PostEditDto dto,
            Guid id)
        {
            var response = await _loans Service.EditAsync(dto, id);

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
            });
        }
    }
}
