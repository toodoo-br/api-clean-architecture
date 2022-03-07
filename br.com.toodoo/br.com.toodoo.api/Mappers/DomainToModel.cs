using AutoMapper;
using br.com.toodoo.api.Models;
using br.com.toodoo.core.FieldAggregate;
using br.com.toodoo.core.FormAggregate;

namespace br.com.toodoo.api.Mappers;

public class DomainToModel : Profile
{
    public DomainToModel()
    {
        CreateMap<Form, FormModel>().ReverseMap();
        CreateMap<FieldModel, Field>();

        CreateMap<Field, FieldModel>()
            .ForMember(d => d.FormName, opt => opt.MapFrom(src => src.Form.Name));
    }
}