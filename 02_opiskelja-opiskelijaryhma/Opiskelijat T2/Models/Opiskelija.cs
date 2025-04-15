using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opiskelijat_T2.Models
{
    public class Opiskelija
    {
        public int Tunniste { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public int RyhmaId { get; set; }

    }
}
