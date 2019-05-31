using Hotel.Exceptions;
using Hotel.Util;
using Hotel.View;
using Hotel.ViewModel;
using System.Windows;

namespace Hotel.Operations
{
    public class LoginOperations
    {
        private LoginVM model;

        public LoginOperations(LoginVM model)
        {
            this.model = model;
        }

        public void Login(object param)
        {
            LoginVM viewModel = param as LoginVM;
            try
            {
                LoginActions.Login(viewModel.Users, viewModel.Username, viewModel.Password);

                switch (Utils.AuthUser.Type)
                {
                    case "admin":
                        Administrator adminWindow = new Administrator();
                        adminWindow.ShowDialog();
                        break;
                    case "client":
                        Client clientWindow = new Client();
                        clientWindow.ShowDialog();
                        break;
                    case "employee":
                        Employee employeeWindow = new Employee();
                        employeeWindow.ShowDialog();
                        break;
                    case "none":
                        Unauthenticated newUser = new Unauthenticated();
                        newUser.ShowDialog();
                        break;
                    default:
                        MessageBox.Show("Type not allowed.");
                        break;
                    
                }
            }
            catch (LoginException ex)
            {
                MessageBox.Show("Eroare la login: " + ex.Message, "Eroare", MessageBoxButton.OKCancel);
            }
        }

        public void RegisterClient(object param)
        {
            LoginVM viewModel = param as LoginVM;
            try
            {
                LoginActions.Register(viewModel.Users, viewModel.Username, viewModel.Password, "client");
                MessageBox.Show("Te-ai inregistrat cu succes!", "Succes", MessageBoxButton.OKCancel);
            }
            catch (LoginException ex)
            {
                MessageBox.Show("Eroare la inregistrare: " + ex.Message, "Eroare", MessageBoxButton.OKCancel);
            }
        }

        public void RegisterAdmin(object param)
        {
            LoginVM viewModel = param as LoginVM;
            try
            { 
            
                LoginActions.Register(viewModel.Users, viewModel.Username, viewModel.Password, "admin");
                MessageBox.Show("Te-ai inregistrat cu succes!", "Succes", MessageBoxButton.OKCancel);
            }
            catch (LoginException ex)
            {
                MessageBox.Show("Eroare la inregistrare: " + ex.Message, "Eroare", MessageBoxButton.OKCancel);
            }
        }

        public void RegisterEmployee(object param)
        {
            LoginVM viewModel = param as LoginVM;
            try
            {

                LoginActions.Register(viewModel.Users, viewModel.Username, viewModel.Password, "employee");
                MessageBox.Show("Te-ai inregistrat cu succes!", "Succes", MessageBoxButton.OKCancel);
            }
            catch (LoginException ex)
            {
                MessageBox.Show("Eroare la inregistrare: " + ex.Message, "Eroare", MessageBoxButton.OKCancel);
            }
        }

    }
}
