using AutoMapper;
using br.com.toodoo.api.Models;
using br.com.toodoo.core.FormAggregate;

namespace br.com.toodoo.api.Mappers;

public class DomainToModel : Profile
{
    public DomainToModel()
    {
        CreateMap<Form, FormModel>().ReverseMap();
    }
}