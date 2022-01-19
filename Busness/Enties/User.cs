using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Enties
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string? EmailComfirm { get; set; }
        public string Avatar { get; set; }

        public virtual Person Person { get; set; }
        public virtual IEnumerable<Chat> Chats { get; set; }
        public virtual IEnumerable<DialogueParticipant> Participant { get; set; }
        public virtual IEnumerable<Message> Messages { get; set; }
    }
}
