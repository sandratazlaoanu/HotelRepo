using System;

namespace Hotel.Model
{ 
    public class User
    {
        private int id;
        private String username;
        private String password;
        private String type;
        private bool isActive;

        public User(string username)
        {
            this.Username = username;
        }
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.isActive = true;
        }
        public User(int id, string username, string password, String type)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Type = type;
            this.isActive = true;
        }
        public User(string username, string password, String type)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Type = type;
            this.isActive = true;
        }
        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public String Type { get => type; set => type = value; }
        public bool IsActive { get => isActive; set => isActive = value; }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var item = obj as User;

            if (item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override string ToString()
        {
            return string.Format("User: {0}", this.Username);
        }

        public string ToWriteString()
        {
            return string.Format("{0} {1} {2}", this.Username, this.Password, this.Type);
        }
    }
}

