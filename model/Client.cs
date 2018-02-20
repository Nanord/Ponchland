using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ponchland.generalData;

namespace Ponchland.model
{
    class Client : Ponchland
    {
        public string Login { get; set; }
        public string Address { get; set; }
        public string Last_name { get; set; }
        public List<Order> Order { get; set; }

        public Client(UserRegistr user)
        {
            Id = user.id;
            Login = user.user.login;
            Name = user.name;
            Address = user.address;
            Last_name = user.last_name;
            Order = new List<model.Order>();
        }

        public void AddOrder(Order order)
        {
            Order.Add(order);
        }
    }
}