using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioGitHub.Dominio
{
    public class Favorite
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime UpdateLast { get; set; }
        public string Owner { get; set; }
        public string Name { get; set; }
    }
}
