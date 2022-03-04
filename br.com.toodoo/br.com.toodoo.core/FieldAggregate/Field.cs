using br.com.toodoo.core.FormAggregate;
using br.com.toodoo.sharedkernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.toodoo.core.FieldAggregate
{
    public class Field : BaseEntity
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
        public int FormId { get; set; }

        public Form? Form { get; set; }
    }
}
