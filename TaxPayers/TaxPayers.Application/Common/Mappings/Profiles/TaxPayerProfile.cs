using AutoMapper;
using TaxPayers.Application.Features.TaxPayer.Queries;
using TaxPayers.Application.Extensions;

namespace TaxPayers.Application.Common.Mappings.Profiles
{
    public class TaxPayerProfile : Profile
    {
        public TaxPayerProfile()
        {   
            CreateMap<Domain.Entities.TaxPayer, GetTaxPayersWithPaginationDto>()
                .ForMember(dest => dest.TypeDescription, opt =>
                    opt.MapFrom(src => src.Type.GetEnumDescription()))
                .ForMember(dest => dest.StatusDescription, opt =>
                    opt.MapFrom(src => src.Status.GetEnumDescription()));
        }
    }
}
