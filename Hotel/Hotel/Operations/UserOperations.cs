using Hotel.View;
using Hotel.ViewModel;

namespace Hotel.Operations
{
    public class UserOperations
    {
        private UserVM vm;
        
        public UserOperations(UserVM vm)
        {
            this.vm = vm;
        }

        public void Exit(object param)
        {
            AllUsers window = new AllUsers();
            window.Exit();
        }
    }
}
