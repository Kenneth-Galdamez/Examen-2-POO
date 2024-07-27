using AutoMapper;
using ExamenPoo2KennethGaldamez.Database;
using ExamenPoo2KennethGaldamez.Database.Entities;
using ExamenPoo2KennethGaldamez.Dtos.Common;
using ExamenPoo2KennethGaldamez.Dtos.Loans;
using ExamenPoo2KennethGaldamez.Dtos.Prospects;
using ExamenPoo2KennethGaldamez.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogUNAH.API.Services
{
    public class LoansService : ILoansService
    {
        private readonly Examen2Context _context;
        private readonly IAuthService _authService;
        private readonly ILogger<LoansService> _logger;
        private readonly IMapper _mapper;

        public LoansService(Examen2Context context,
            IAuthService authService,
            ILogger<LoansService> logger,
            IMapper mapper)
        {
            this._context = context;
            this._authService = authService;
            this._logger = logger;
            this._mapper = mapper;
        }

        public async Task<ResponseDto<LoanDto>> GetLoansByIdAsync(Guid id)
        {
            var loanEntity = await _context.Loans.FirstOrDefaultAsync(c => c.ClientId == id)


            if (loanEntity is null)
            {
                return new ResponseDto<LoanDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = $"El registo del cliente {id} no fue encontrado."
                };
            }

            var loanDto = _mapper.Map<List<LoanDto>>(loanEntity);

            return new ResponseDto<List<LoanDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro encontrado correctamente",
                Data = loanDto,
            };
        }

        public async Task<ResponseDto<LoanDto>> CreateAsync(LoanCreateDto dto)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {

                    var loanEntity = _mapper.Map<LoanEntity>(dto);

                    var existing = await _context.Prospects
                        .Where(t => dto.identity_number == t.identity_number)

                    if (existing is null)
                    {
                        var newprospects = new ProspectEntity
                        {
                            client_Name = dto.client_Name,
                            identity_number = dto.identity_number,
                        }
                        _context.Prospects.Add(newprospects);
                        await _context.SaveChangesAsync();
                    }

                    else
                    {

                        loanEntity.ClientId = existing.Id;

                    };


                    _context.Loans.Add(loanEntity);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    var loanDto = _mapper.Map<LoanDto>(loanEntity);

                    return new ResponseDto<LoanDto>
                    {
                        StatusCode = 201,
                        Status = true,
                        Message = "Registro creado correctamente",
                        Data = loanDto
                    };
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(e, "Error al crear");
                    return new ResponseDto<LoanDto>
                    {
                        StatusCode = 500,
                        Status = false,
                        Message = "Se produjo un error al crear."

                    };
                }

            }
        }


    }
}
