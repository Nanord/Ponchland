using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ponchland.generalData;

namespace Ponchland.model
{
    class Order
    {
        public int Id { get; set; }
        public String Date { get; set; }
        public bool Pickup { get; set; }
        public bool Cash { get; set; }
        private Dictionary<Product, int> product;

        public Dictionary<Product, int> GetProduct()
        {
            return product;
        }

        public void SetProduct(Dictionary<UserProduct, int> userProduct)
        {
            List<int> count = userProduct.Values.ToList();
            Dictionary<Product, int> product = new Dictionary<Product, int>();
            int i = 0;
            foreach (UserProduct tmpUserProduct in userProduct.Keys)
            {
                Product tmpProduct = new Product(tmpUserProduct);
                product.Add(tmpProduct, count[i]);
                i++;
            }
            this.product = product;
        }

        public Order(UserOrder order)
        {
            Id = order.id;
            Date = order.date;
            Pickup = order.pickup;
            Cash = order.cash;
            SetProduct(order.product);

        }
    }
}
