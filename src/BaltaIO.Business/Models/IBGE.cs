using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaIO.Business.Models
{
    public class IBGE
    {
        public int id { get; set; }

        public string Codigo { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }

    }
}
