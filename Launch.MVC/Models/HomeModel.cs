using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Launch.MVC.Models
{
    public class HomeModel
    {
        public IEnumerable<CandidatoModel> ListCandidatos { get; set; }
        public CandidatoModel CanditatoRei { get; set; }
    }
}
