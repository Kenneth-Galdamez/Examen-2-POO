using ExamenPoo2KennethGaldamez.Dtos.Loans;
using ExamenPoo2KennethGaldamez.Dtos.Common;

namespace ExamenPoo2KennethGaldamez.Services.Interfaces
{
    public interface ILoansService
    {

        Task<ResponseDto<LoanDto>> GetLoansByIdAsync(Guid id);
        Task<ResponseDto<LoanDto>> CreateAsync(LoanCreateDto dto);

    }
}