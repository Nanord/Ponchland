using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using Ponchland.generalData;

namespace Ponchland.db
{
    class Db
    {
        private static Db instance;

        private Db()
        {
        }

        public static Db getInstance()
        {
            if (instance == null)
                instance = new Db();
            return instance;
        }
        /// <summary>
        /// Подключение к MySql серверу
        /// </summary>
        /// <returns>Объект подключения</returns>
        private MySqlCommand Connection()
        {
            string connStr = "Data source = localhost; UserId = root; Password = 151074; database = course; SslMode=none; ";
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand comm = new MySqlCommand();
            comm.Connection = conn;
            return comm;
        }

        /// <summary>
        /// Выгрузка данных из MySql
        /// </summary>
        public bool User(User user)
        {
            if (!user.noNull())
            {
                return false;
            }
            bool compare = false;
            MySqlCommand comm = Connection();

            string commStr = "SELECT login, password FROM user;";

            MySqlDataReader reader;
            try
            {
                comm.Connection.Open();
                comm.CommandText = commStr;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (user.compare(reader.GetString(0), reader.GetString(1)))
                    {
                        compare = true;
                        break;
                    }
                }
                reader.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                comm.Connection.Close();
            }
            if (compare)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Проверка есть ли такой пользователь
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private bool CheckReg(string login)
        {
            bool compare = true;
            MySqlCommand comm = Connection();
            string checkCommStr = "SELECT login FROM user;";
            MySqlDataReader reader;
            try
            {
                comm.Connection.Open();

                comm.CommandText = checkCommStr;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (compare = (login == reader.GetString(0)))
                        break;
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                comm.Connection.Close();
            }
            return compare;
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public String Regisrg(UserRegistr user)
        {
            if (!user.noNull())
            {
                return "Data empty";
            }
            if (CheckReg(user.user.login))
            {
                return "This login is already used";
            }
            MySqlCommand comm = Connection();

            String CommStr = "INSERT INTO user (login, password, address, name, last_name) VALUES ('" + user.user.login + "', '" + user.user.password + "', '" + user.address + "', '" + user.name + "', '" + user.last_name + "' );";
            try
            {
                comm.Connection.Open();

                comm.CommandText = CommStr;
                comm.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                return "Error: \r\n{0}" + ex.ToString();
            }
            finally
            {
                comm.Connection.Close();
            }
            return "Готово!";
        }

        public List<UserRegistr> LoadUser(User tmpUser)
        {
            List<UserRegistr> client = new List<UserRegistr>();
            MySqlCommand comm = Connection();

            String CommStr = "SELECT id, login, name, last_name, address FROM user WHERE id != 1";
            if (!tmpUser.compareAdmin())
            {
                CommStr += " and login = '" + tmpUser.login + "' and " + "password = '" + tmpUser.password + "' ";
            }
            MySqlDataReader reader;
            try
            {
                comm.Connection.Open();

                comm.CommandText = CommStr;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    UserRegistr tmp;
                    tmp.id = reader.GetInt32(0);
                    tmp.user = new User(reader.GetString(1));
                    tmp.name = reader.GetString(2);
                    tmp.last_name = reader.GetString(3);
                    tmp.address = reader.GetString(4);
                    client.Add(tmp);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                comm.Connection.Close();
            }
            return client;
        }

        public List<UserOrder> LoadOrder(UserRegistr tmpUser)
        {
            List<UserOrder> order = new List<UserOrder>();
            String str;
            MySqlCommand comm = Connection();

            String CommOrderStr = "select * from orders where user in (select id from user ";
            String CommProductStr = "select orders.id, product.*, orders_product.count, category.* from category, orders right join orders_product on orders_product.orders = orders.id right join product on product.id = orders_product.product where product.category = category.id and orders.user in (select id from user ";
            if (!tmpUser.user.compareAdmin())
            {
                str = "where login = '" + tmpUser.user.login + "');";
            }
            else
            {
                str = ")";
            }
            CommOrderStr += str;
            CommProductStr += str;

            MySqlDataReader reader;
            try
            {
                comm.Connection.Open();

                comm.CommandText = CommOrderStr;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    UserOrder tmpOrder;
                    tmpOrder.id = reader.GetInt32(0);
                    tmpOrder.date = reader.GetString(1);
                    tmpOrder.pickup = (reader.GetInt32(3) == 1) ? true : false;
                    tmpOrder.cash = (reader.GetInt32(4) == 1) ? true : false;
                    tmpOrder.user = tmpUser;
                    tmpOrder.product = new Dictionary<UserProduct, int>();
                    order.Add(tmpOrder);
                }
                reader.Close();

                comm.CommandText = CommProductStr;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    foreach (UserOrder tmpOrder in order)
                    {
                        if (tmpOrder.id == reader.GetInt32(0))
                        {
                            UserProduct tmpProduct;
                            tmpProduct.id = reader.GetInt32(1);
                            tmpProduct.name = reader.GetString(2);
                            tmpProduct.cost = reader.GetInt32(3);
                            tmpProduct.description = reader.GetString(5);
                            tmpProduct.category.id = reader.GetInt32(7);
                            tmpProduct.category.name = reader.GetString(8);
                            tmpProduct.category.description = reader.GetString(9);

                            tmpOrder.product.Add(tmpProduct, reader.GetInt32(6));
                        }
                    }
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                comm.Connection.Close();
            }
            return order;
        }

        public List<UserProduct> LoadProduct()
        {
            List<UserProduct> product = new List<UserProduct>();
            MySqlCommand comm = Connection();

            String CommStr = "SELECT * FROM product join category on category.id = product.category";
            MySqlDataReader reader;
            try
            {
                comm.Connection.Open();

                comm.CommandText = CommStr;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    UserProduct tmp;
                    tmp.id = reader.GetInt32(0);
                    tmp.name = reader.GetString(1);
                    tmp.cost = reader.GetInt32(2);
                    tmp.description = reader.GetString(4);
                    tmp.category.id = reader.GetInt32(5);
                    tmp.category.name = reader.GetString(6);
                    tmp.category.description = reader.GetString(7);
                    product.Add(tmp);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                comm.Connection.Close();
            }
            return product;
        }

        public List<UserCategory> LoadCategoey()
        {
            List<UserCategory> category = new List<UserCategory>();
            MySqlCommand comm = Connection();

            String CommStr = "SELECT * FROM category";
            MySqlDataReader reader;
            try
            {
                comm.Connection.Open();

                comm.CommandText = CommStr;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    UserCategory tmp;
                    tmp.id = reader.GetInt32(0);
                    tmp.name = reader.GetString(1);
                    tmp.description = reader.GetString(2);
                    category.Add(tmp);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                comm.Connection.Close();
            }
            return category;
        }



        public String MakeOrder(UserOrder order)
        {
            if (!order.noNull())
            {
                return "Data empty";
            }
            MySqlCommand comm = Connection();

            List<String> cond = new List<String>();

            String pickup = order.pickup ? "1" : "0",
                cash = order.cash ? "1" : "0";

            String CommStr = "insert into orders (date, user, pickup, cash) values ('" + order.date + "', " + order.user.id + ", " + pickup + ", " + cash + ");";
            CommStr += "insert into orders_product(orders, product, count) values ";
            foreach (KeyValuePair<UserProduct, int> tmpProduct in order.product)
            {
                cond.Add("((select MAX(id) from orders), " + tmpProduct.Key.id + ", " + tmpProduct.Value + ")");
            }
            CommStr += String.Join(", ", cond);
            CommStr += ";";
            try
            {
                comm.Connection.Open();

                comm.CommandText = CommStr;
                comm.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                return "Error: \r\n{0}" + ex.ToString();
            }
            finally
            {
                comm.Connection.Close();
            }
            return "Готово!";
        }

        public string AddProduct(UserProduct product)
        {
            MySqlCommand comm = Connection();

            String CommStr = "insert into product (name, cost, category, description) values ('" + product.name + "', " + product.cost + ", " + product.category.id + ", '" + product.description + "');";
            try
            {
                comm.Connection.Open();

                comm.CommandText = CommStr;
                comm.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                return "Error: \r\n{0}" + ex.ToString();
            }
            finally
            {
                comm.Connection.Close();
            }
            return "Готово!";
        }

        public string AddCategory(UserCategory category)
        {
             MySqlCommand comm = Connection();

            String CommStr = "insert into category (name, description) values ('" + category.name + "', '" + category.description + "');";
            try
            {
                comm.Connection.Open();

                comm.CommandText = CommStr;
                comm.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                return "Error: \r\n{0}" + ex.ToString();
            }
            finally
            {
                comm.Connection.Close();
            }
            return "Готово!";
        }
    }
}
