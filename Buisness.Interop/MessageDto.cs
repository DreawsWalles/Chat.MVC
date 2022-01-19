using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Interop
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreate { get; set; }
        public bool isRead { get; set; }

        public virtual UserDto User { get; set; }
        public virtual ChatDto Chat { get; set; }
    }
}
