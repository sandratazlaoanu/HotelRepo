using Hotel.Exceptions;
using Hotel.Model;
using System;
using System.Collections.Generic;
using Hotel.Repository;
using Hotel.View;

namespace Hotel.Util
{
    public static class LoginActions
    {

        public static void Login(List<User> users, string username, string password)
        {
            UserRepository repo = new UserRepository();

            users = repo.GetAll();
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


        public static void Register(List<User> users, string username, string password, String userType)
        {
            UserRepository repo = new UserRepository();

            users = repo.GetAll();

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
            User userToAdd = new User(username, password,userType);
            users.Add(userToAdd);

            repo.Save(userToAdd);
        }
        public static void ViewUsers()
        {
            AllUsers view = new AllUsers();
            view.Show();
        }
        public static void NotLoggedView()
        {
            Unauthenticated view = new Unauthenticated();
            view.Show();
        }
        public static void Close()
        {
            MainWindow main = new MainWindow();
            main.Close();
        }
    }
}
