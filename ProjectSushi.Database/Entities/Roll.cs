using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSushi.Database.Entities
{
    public record Roll
    {
        public int Id { get; set; }
        public int CategoryId { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Composition { get; set; } = string.Empty;
        public int Weight { get; set; } = default;
        public decimal Price { get; set; } = default;
        public string ImageId { get; set; } = string.Empty;

        public Category Category { get; set; } = new Category();
    }
}
