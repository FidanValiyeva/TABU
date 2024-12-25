using AutoMapper;
using Babu.DTOs.Languages;
using Babu.Entities;

namespace Babu.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto, Language>()
                .ForMember(l=>l.Icon,lcd=>lcd.MapFrom(x=>x.IconUrl));
            CreateMap<Language, LanguagesGetDto>().ReverseMap();
        }
    }
}
