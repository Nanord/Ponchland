using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponchland.generalData;
using Ponchland.model;

namespace Ponchland.controller.filter
{
    abstract class FilterContains : IFilter
    {
        public string Value { get; set; }

        protected bool Contains(string con) => Value.Contains(con);

        public abstract bool Check(Product product);
    }
  
    class nameFilterContains : FilterContains
    {
        public override bool Check(Product product) => product.Name.Contains(Value);
    }

    class descrFilterContains : FilterContains
    {
        public override bool Check(Product product) => product.Description.Contains(Value);
    }
}
