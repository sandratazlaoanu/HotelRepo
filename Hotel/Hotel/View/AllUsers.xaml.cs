using System.Windows;

namespace Hotel.View
{
    /// <summary>
    /// Interaction logic for AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Window
    {
        public AllUsers()
        {
            InitializeComponent();

            //UserRepository repo = new UserRepository();
            //List<User> items = repo.GetAll();
            //UserView.Items.Add(items);

        }

        public void Exit()
        {
            this.Close();
        }
    }
}
