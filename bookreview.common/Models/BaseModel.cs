﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookreview.common.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        public ErrorModel Error { get; set; }
    }
}
