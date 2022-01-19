using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Interop
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? EmailComfirm { get; set; }
        public string Avatar { get; set; }

        public virtual PersonDto Person { get; set; }
        public virtual IEnumerable<ChatDto> Chats { get; set; }
        public virtual IEnumerable<MessageDto> Messages { get; set; }
    }
}
