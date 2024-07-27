using AutoMapper;
using ExamenPoo2KennethGaldamez.Database.Entities;
using ExamenPoo2KennethGaldamez.Dtos.Loans;
using ExamenPoo2KennethGaldamez.Dtos.Prospects;

namespace BlogUNAH.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForLoans();
            MapsForProspects();
        }

        private void MapsForLoans()
        {
            CreateMap<LoanEntity, LoanDto>()
                .ForMember(dest => dest.levelpayment, opt => opt.MapFrom(src => (src.Loan_amount) / Math.Pow((1 - (1 + src.tasa_interes)), -src.plazo) / src.tasa_interes));
                .ForMember(dest => dest.saldo, opt => opt.MapFrom(src => src.Loan_amount + ((src.Loan_amount) / Math.Pow((1 - (1 + src.tasa_interes)), -src.plazo) / src.tasa_interes)));


            CreateMap<LoanCreateDto, LoanEntity>();

        }

        private void MapsForProspects()
        {
            CreateMap<ProspectEntity, ProspectDto>()
            CreateMap<ProspectCreateDto, ProspectEntity>();
        }
    }
}
