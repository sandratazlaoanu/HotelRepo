using System;
using Hotel.Model;

namespace Hotel.Util
{
    public class Validator
    {
        public static bool IsMatchingUser(User user, string username, string password)
        {
            return (user.Username.Equals(username) && user.Password.Equals(password));
        }

        public static bool IsMatchingUsername(User user, string username)
        {
            return (user.Username.Equals(username));
        }

        //public static bool IsMatchingProductName(Product product, string name)
        //{
        //    return (product.Name.Equals(name));
        //}

        public static bool IsPriceAnInt(string price)
        {
            int aux = 0;
            if (int.TryParse(price, out aux))
            {
                return true;
            }

            return false;
        }
    }
}
