using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ponchland.db;
using Ponchland.model;
using Ponchland.generalData;
using Ponchland.controller.filter;

namespace Ponchland.controller
{
    public class Controller
    {
        private Db db;
        private List<Client> client;
        private List<Category> category;

        public bool StatusUser { get; private set; }

        public Controller()
        {
            db = Db.getInstance();
            this.category = new List<Category>();
            this.client = new List<Client>();
        }

        public bool User(User user)
        {
            Hash hash = new Hash(user.password);
            user.password = hash.sum;

            if (db.User(user))
            {
                StatusUser = (user.login == "Admin" && user.password == "121115105115") ? true : false; ;
                return true;
            }
            else return false;
        }

        public string Registr(UserRegistr user)
        {
            Hash hash = new Hash(user.user.password);
            user.user.password = hash.sum;

            return db.Regisrg(user);
        }

        public List<UserRegistr> LoadUser(User user)
        {
            Hash hash = new Hash(user.password);
            user.password = hash.sum;

            List<UserRegistr> client;
            client = db.LoadUser(user);
            foreach (UserRegistr tmp in client)
            {
                this.client.Add(new Client(tmp));
            }

            return client;
        }

        private int idClient(UserRegistr user)
        {
            for(int i = 0; i < client.Count; i++)
            {
                if(client[i].Id == user.id)
                {
                    return i;
                }
            }
            return 0;
        }

        public List<UserOrder> LoadOrder(UserRegistr user)
        {
            List<UserOrder> order;
            order = db.LoadOrder(user);
            int i = idClient(user);
            foreach (UserOrder tmpOrder in order)
            {
                client[i].AddOrder(new Order(tmpOrder));
            }
            return order;
        }

        private int idCategory(UserCategory cat)
        {
            for (int i = 0; i < category.Count; i++)
            {
                if (category[i].Id == cat.id)
                {
                    return i;
                }
            }
            return 0;
        }

        public List<UserProduct> LoadProduct()
        {
            List<UserProduct> product;
            product = db.LoadProduct();
            category = new List<Category>();
            List<UserCategory> catDb = db.LoadCategoey();
            foreach(UserCategory tmp in catDb)
            {
                category.Add(new Category(tmp));
            }
            //int i = 0;
            //foreach (UserProduct tmpProduct in product)
            //{
            //    if (i > 1 && category[i - 1].Id == tmpProduct.category.id)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        category.Add(new Category(tmpProduct.category));
            //    }
            //    i++;

            //}


            foreach (UserProduct tmp in product)
            {
                category[idCategory(tmp.category)].AddProduct(new Product(tmp));
            }
            return product;
        }

        public List<UserCategory> LoadCategory() => db.LoadCategoey();

        public string MakeOrder(UserOrder order)
        {
            this.client[idClient(order.user)].AddOrder(new Order(order));
            return db.MakeOrder(order);
        }

        public string AddProduct(UserProduct product)
        {
            if(category.Count == 0)
            {
                LoadProduct();
            }
            int i = idCategory(product.category);
            this.category[i].AddProduct(new Product(product));
            return db.AddProduct(product);
        }

        public string AddCategory(UserCategory category)
        {
            this.category.Add(new Category(category));
            return db.AddCategory(category);
        }

        public List<int> Filter(Dictionary<FieldProduct, FieldType> field)
        {
            FilterContr filter = new FilterContr(category, field);
            List<Product> listProduct =  filter.GetFilterProduct();
            List<int> ret = new List<int>();
            foreach(Product tmp in listProduct)
            {
                ret.Add(tmp.Id);
            }
            return ret;
        }

    }
}
