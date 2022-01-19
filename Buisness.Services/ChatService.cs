using AutoMapper;
using Buisness.Enties;
using Buisness.Interop;
using Buisness.Repositories.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;

        public ChatService(IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public ChatDto CreateDto(ChatDto model)
        {
            var entity = _mapper.Map<Chat>(model);
            _chatRepository.CreateOrUpdate(entity);
            return _mapper.Map<ChatDto>(entity);
        }

        public IEnumerable<ChatDto> GetAll()
        {
            var chats = _chatRepository.Query();
            return _mapper.Map<IEnumerable<Chat>, IEnumerable<ChatDto>>(chats);
        }

        public IEnumerable<ChatDto> GetByName(string name)
        {
            var chats = _chatRepository.Query()
                .Where(element => element.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));
            return _mapper.Map<IEnumerable<Chat>, IEnumerable<ChatDto>>(chats);
        }
    }
}
