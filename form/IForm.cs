using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ponchland.controller;
using Ponchland.generalData;

namespace Ponchland
{
    public interface IForm
    {
        Controller controller {  get;  set; }
        void Init(Controller controller, User user);
    }

    public interface IAdd : IForm
    {
        new void Init(Controller controller, User user);
    }
}
