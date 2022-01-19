using Buisness.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface IMessageService
    {
        public MessageDto CreateMessage(MessageDto model);
        public IEnumerable<MessageDto> GetAll();
        public IEnumerable<MessageDto> FindByContent(string content);
    }
}
