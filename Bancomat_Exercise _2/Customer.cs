using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bancomat_Exercise
{
    public class Customer
    {

        public string Username { get; }
        public string Password { get; }
        public string IdCustomer { get; }
        private bool IsBan;

        //public customer(string username, string password) //costruttore definitivo
        //{
        //    username = username;
        //    password = password;
        //    idcustomer = guid.newguid().tostring();


        //}
        public Customer(string username, string password, string id)
        {
            Username = username;
            Password = password;
            IdCustomer = id;
            IsBan = false;
        }

        public void Ban()
        {
            IsBan = true;
        }
        public void UnBan()
        {
            IsBan = false;
        }

        public bool IsBanned()
        {
            return IsBan;
        }





    }
}

