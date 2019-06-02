using Hotel.Model;
using System.Collections.Generic;
using Hotel.Repository;
using System.Data;
using System;

namespace Hotel.Util
{
    public static class Utils
    {
        private static UserRepository userRepo = new UserRepository();
        private static RoomRepository roomRepository;
        private static List<User> users;

        public static List<User> Users
        {
            get
            {
                return userRepo.GetAll();
            }
            set
            {
                users = userRepo.GetAll();
            }
        }
        public static List<Room> Rooms
        {
            get;
            set;
        }
        public static User AuthUser
        {
            get;
            set;
        }

        public static List<User> InitUsers()
        {
            Users = userRepo.GetAll();

            foreach (User user in Users)
            {
                // User userToAdd = new User(AuthUser.Username, AuthUser.Password, AuthUser.Type);
                Users = new List<User>();
                Users.Add(user);
            }
            return Users;
        }

        public static List<Room> InitRooms()
        {
            roomRepository = new RoomRepository();
            Rooms = roomRepository.GetAll();

            return Rooms;
        }
    }
}
