using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponchland.model;

namespace Ponchland.controller.filter
{
    interface IFilter
    {
        string Value { get; set; }
        bool Check(Product product);
    }
}
