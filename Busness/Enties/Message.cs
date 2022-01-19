using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Enties
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreate { get; set; }
        public bool isRead { get; set; }

        public virtual User User { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
