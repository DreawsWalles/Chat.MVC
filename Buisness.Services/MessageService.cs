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
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public MessageDto CreateMessage(MessageDto model)
        {
            var entity = _mapper.Map<Message>(model);
            _messageRepository.CreateOrUpdate(entity);
            return _mapper.Map<MessageDto>(entity);
        }

        public IEnumerable<MessageDto> FindByContent(string content)
        {
            var messages = _messageRepository.Query()
                .Where(element => element.Content.Contains(content, StringComparison.InvariantCultureIgnoreCase));
            return _mapper.Map<IEnumerable<Message>, IEnumerable<MessageDto>>(messages);
        }

        public IEnumerable<MessageDto> GetAll()
        {
            var messages = _messageRepository.Query();
            return _mapper.Map<IEnumerable<Message>, IEnumerable<MessageDto>>(messages);
        }
    }
}
