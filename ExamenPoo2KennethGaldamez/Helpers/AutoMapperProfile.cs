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
            CreateMap<LoanEntity, LoanDto>();
            CreateMap<LoanCreateDto, LoanEntity>();
            CreateMap<LoanEditDto,LoanEntity>();
        }

        private void MapsForProspects() 
        {
            CreateMap<ProspectEntity, ProspectDto>();
            CreateMap<ProspectCreateDto, ProspectEntity>();
            CreateMap<ProspectEditDto, ProspectEntity>();
        }
    }
}
