using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookreview.common.Models
{
    public class BookViewModel: BaseModel
    {
        public string Title { get; set; }

        public List<AuthorModel> Authors { get; set; }

        public string Synoposis { get; set; }

        public List<string> Tags { get; set; }

        /// <summary>
        /// Preferabbly ISBN 13 as this is more recent version, but will accept ISBN 10
        /// </summary>
        public string ISBN { get; set; }

        public string YearPublished { get; set; }

        public string Publisher { get; set; }
    }
}
