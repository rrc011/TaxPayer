using AutoMapper;
using TaxPayers.Application.Extensions;
using TaxPayers.Application.Features.TaxPayer;
using TaxPayers.Domain.Entities;

namespace TaxPayers.Application.Common.Mappings.Profiles
{
    public class TaxPayerProfile : Profile
    {
        public TaxPayerProfile()
        {   
            CreateMap<TaxPayer, GetTaxPayersWithPaginationDto>()
                .ForMember(dest => dest.TypeDescription, opt =>
                    opt.MapFrom(src => src.Type.GetEnumDescription()))
                .ForMember(dest => dest.StatusDescription, opt =>
                    opt.MapFrom(src => src.Status.GetEnumDescription()));
        }
    }
}
