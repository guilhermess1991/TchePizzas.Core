using System.Text;
using FluentValidator;
using TchePizzas.Shared.Entities;

namespace TchePizzas.Domain.Entities
{
    public class User : Entity
    {

        //Contructor//
        public User(string username, string password, string confirmPassword, Customer customer)
        {
            Username = username;
            Password = EncryptPassword(password);
            Active = true;
            Customer = customer;


            //Class validations//
            new ValidationContract<User>(this)
                .AreEquals(x => x.Password, EncryptPassword(confirmPassword), "As senhas não coincidem.");

			//Inherit validations//
			AddNotifications(customer.Notifications);
        }

        //Properties//
        public string Username{get;private set;}

        public string Password{get;private set;}

        public bool Active{get;private set;}

        public Customer Customer{get;private set;}


		//Methods//
		public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        string EncryptPassword(string pass){

            if (string.IsNullOrEmpty(pass)) return "";

            var password = string.Empty;
            password = (pass += "|23f881acb35e247c8daa79d8c5ce2665");

            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash((Encoding.ASCII.GetBytes(password)));
            var sbString = new StringBuilder();

            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            if (string.IsNullOrEmpty(sbString.ToString()))
                return null;
            
            return sbString.ToString();
        }

    }

}
