using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSushi.Database.Entities
{
    public record Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public List<Roll> Rolls { get; set; } = new List<Roll>();
    }
}
