using AutoMapper;
using MonqService.Models;

namespace MonqService.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Пытался сделать через мапинги, чтобы было красиво, но там из-за разного типа свойств сделать это у меня не получилось
            //Оставил этот код здесь чтоб был (:
            CreateMap<MailDto, Mail>();
        }
    }
}
