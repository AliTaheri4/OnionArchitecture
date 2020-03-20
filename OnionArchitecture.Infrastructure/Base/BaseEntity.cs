using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Infrastructure.Base
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public string CreatedName { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string EditedName { get; set; }
        public DateTime? EditedTime { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
