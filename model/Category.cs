using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ponchland.generalData;

namespace Ponchland.model
{
    class Category : Ponchland
    {

        public String Description { get; set; }
        public List<Product> Product { get; set; }

        public Category(UserCategory category)
        {
            Id = category.id;
            Name = category.name;
            Description = category.description;
            Product = new List<model.Product>();
        }

        public void AddProduct(Product product)
        {
            Product.Add(product);
        }

        //public UserProduct getStringProduct(Product getProduct)
        //{
        //    UserProduct product;
        //    foreach (Product tmp in Product)
        //    {
        //        if (getProduct == tmp)
        //        {
        //            product.id = tmp.Id;
        //            product.name = tmp.Name;
        //            product.cost = tmp.Cost;
        //            product.description = tmp.Description;
        //            product.category.id = Id;
        //            product.category.name = Name;
        //            product.category.description = Description;
        //            return product;
        //        }

        //    }
        //}
    }
}
