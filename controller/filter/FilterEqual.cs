using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponchland.generalData;
using Ponchland.model;

namespace Ponchland.controller.filter
{
    abstract class FilterEqual : IFilter
    {
        public string Value { get; set; }
        public abstract bool Check(Product product);
    }

    class nameFilterEqual : FilterEqual
    {
        public override bool Check(Product product) => (
            product.Name == Value ? true : false);
    }
    
    class costFilterMore : FilterEqual
    {
        public override bool Check(Product product) => (
            product.Cost >= Convert.ToInt32(Value) ? true : false);
    }
    class costFilterLess : FilterEqual
    {
        public override bool Check(Product product) => (
            product.Cost <= Convert.ToInt32(Value) ? true : false);
    }

    class descrFilterEqual : FilterEqual
    {
        public override bool Check(Product product) => (
           product.Description == Value ? true : false);
    }
}
