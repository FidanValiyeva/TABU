using AutoMapper;
using Babu.Entities;
using Babu.Validators.Games;

namespace Babu.Profiles
{
    public class GameProfile:Profile
    {
        public GameProfile() 
        {
            CreateMap<GameCreateDto, Game>();

        }
    }
}
