using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atomic.chicken.common.Models
{
    public class PublisherModel
    {
        public int PublisherId { get; set; }

        public string? Name { get; set; }
    }
}
