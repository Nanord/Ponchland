using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ponchland.generalData;

namespace Ponchland.model
{
    class Product : Ponchland
    {
        public int Cost { get; set; }
        public String Description { get; set; }

        public Product(UserProduct product)
        {
            Id = product.id;
            Name = product.name;
            Cost = product.cost;
            Description = product.description;
        }

        
    }
}
