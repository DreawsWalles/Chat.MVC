using Buisness.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface IChatService
    {
        public ChatDto CreateDto(ChatDto model);
        public IEnumerable<ChatDto> GetAll();
        public IEnumerable<ChatDto> GetByName(string name);
    }
}
