using AutoMapper;
using Buisness.Enties;
using Buisness.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Person, PersonDto>();
            CreateMap<Message, MessageDto>();
            CreateMap<DialogueParticipant, DialogueParticipantDto>();
            CreateMap<Chat, ChatDto>();

            CreateMap<ChatDto, Chat>();
            CreateMap<DialogueParticipantDto, DialogueParticipant>();
            CreateMap<MessageDto, Message>();
            CreateMap<PersonDto, Person>();
            CreateMap<UserDto, User>();
        }
    }
}
