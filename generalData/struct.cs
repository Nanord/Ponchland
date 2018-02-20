using System.Collections.Generic;
namespace Ponchland.generalData
{
    public struct User
    {
        public string login ;
        public string password ;
        public bool status ;

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
            this.status = false;
        }

        public User(string login)
        {
            this.login = login;
            this.password = null;
            this.status = false;
        }

        public bool noNull()
        {
            if (this.login != null || this.password != null)
            {
                return true;
            }
            else return false;
        }

        public bool compare(string login, string password)
        {
            if (login == this.login && password == this.password)
            {
                return true;
            }
            return false;
        }

        public bool compareAdmin()
        {
            if (compare("Admin", "121115105115"))
            {
                return true;
            }
            return false;
        }

    }

    public struct UserRegistr
    {
        public int id ;
        public User user ;
        public string name ;
        public string address ;
        public string last_name ;

        public bool compare(string login, string password, string name, string address, string last_name)
        {
            if (login == user.login && password == user.password && name == this.name && last_name == this.last_name && address == this.last_name)
            {
                return true;
            }
            return false;
        }

        public bool noNull()
        {
            if (user.login != null || user.password != null || name != null || address != null || last_name != null)
            {
                return true;
            }
            else return false;
        }
    }

    public struct UserOrder
    {
        public int id;
        public string date;
        public UserRegistr user;
        public bool pickup;
        public bool cash;
        public Dictionary<UserProduct, int> product;

        public bool noNull()
        {
            if (this.date != null || this.user.user.login != null || this.product != null)
            {
                return true;
            }
            else return false;
        }
    }

    public struct UserProduct
    {
        public int id;
        public string name;
        public int cost;
        public string description;
        public UserCategory category;
    }

    public struct UserCategory
    {
        public int id;
        public string name;
        public string description;
    }

    public enum FieldProduct
    {
        NAME,
        COST,
        DESCRIPRION
    }

    public enum Status
    {
        EQUAL,
        NOT_EQUAL,
        CONTAINS,
        NOT_CONTAINS,
        MORE,
        LESS
    }

    public struct FieldType
    {
        public string value;
        public Status status;
    }
}
