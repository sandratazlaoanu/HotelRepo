using Hotel.Commands;
using Hotel.Model;
using Hotel.Operations;
using Hotel.Property;
using Hotel.Util;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    public class LoginVM : BasePropertyChanged
    {
        public List<User> Users
        {
            get;
            private set;
        }

        public LoginVM()
        {
            Users = Utils.InitUsers();
        }

        private string username;

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
                NotifyPropertyChanged("Username");
            }
        }

        private string password;

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
                NotifyPropertyChanged("Password");
            }
        }

        private String type;

        public String Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
                NotifyPropertyChanged("Type");
            }
        }

        private ICommand loginCommand;

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    LoginOperations operation = new LoginOperations(this);
                    loginCommand = new RelayCommand(operation.Login);
                }

                return loginCommand;
            }
        }

        private ICommand registerAdminCommand;

        public ICommand RegisterAdminCommand
        {
            get
            {
                if (registerAdminCommand == null)
                {
                    LoginOperations operation = new LoginOperations(this);
                    registerAdminCommand = new RelayCommand(operation.RegisterAdmin);
                }

                return registerAdminCommand;
            }
        }

        private ICommand registerClientCommand;

        public ICommand RegisterClientCommand
        {
            get
            {
                if (registerClientCommand == null)
                {
                    LoginOperations operation = new LoginOperations(this);
                    registerClientCommand = new RelayCommand(operation.RegisterClient);
                }

                return registerClientCommand;
            }
        }
        private ICommand registerEmployeeCommand;

        public ICommand RegisterEmployeeCommand
        {
            get
            {
                if (registerEmployeeCommand == null)
                {
                    LoginOperations operation = new LoginOperations(this);
                    registerEmployeeCommand = new RelayCommand(operation.RegisterEmployee);
                }

                return registerEmployeeCommand;
            }
        }



    }
}
