using Hotel.Exceptions;
using Hotel.Model;
using System;
using System.Collections.Generic;
using Hotel.Repository;

namespace Hotel.Util
{
    public static class LoginActions
    {

        public static void Login(List<User> users, string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new LoginException("Complete fields first!");
            }

            foreach (User user in users)
            {
                if (Validator.IsMatchingUser(user, username, password))
                {
                    Utils.AuthUser = user;
                    break;
                }
            }

            if (Utils.AuthUser == null)
            {
                throw new LoginException("Wrong authentification!");
            }
        }

        public static void Register(List<User> users, string username, string password, String usertype)
        {
            UserRepository repo = new UserRepository();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new LoginException("Complete fields first!");
            }

            foreach (User user in users)
            {
                if (Validator.IsMatchingUsername(user, username))
                {
                    throw new LoginException("This username already exists!");
                }
            }

            User userToAdd = new User(username, password);
            users.Add(userToAdd);

            repo.Save(userToAdd);
            //----AICI QUERY PENTRU INSERT IN DB----------
        }
    }
}
