using Hotel.Commands;
using Hotel.Model;
using Hotel.Operations;
using Hotel.Property;
using Hotel.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    public class UserVM : BasePropertyChanged
    {
        private UserRepository repo = new UserRepository();
        private ObservableCollection<User> users;

        public UserVM()
        {
            this.users = ReturnCollection();
        }
        public ObservableCollection<User> ReturnCollection()
        {
            var list = new List<User>();
            list = repo.GetAll();
            var oc = new ObservableCollection<User>();
            foreach (var item in list)
            {
                oc.Add(item);
            }

            return oc;
        }
        public ObservableCollection<User> Users { get => users; set => users = ReturnCollection(); }

        private ICommand exitCommand;

        public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                {
                    UserOperations operation = new UserOperations(this);
                    exitCommand = new RelayCommand(operation.Exit);
                }

                return exitCommand;
            }
        }
    }
}
