﻿using Hotel.Model;
using System.Collections.Generic;
using Hotel.Repository;

namespace Hotel.Util
{
   public static class Utils
    {
        private static UserRepository userRepo;
        private static RoomRepository roomRepository;

        public static List<User> Users
        {
            get;
            set;
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
            userRepo = new UserRepository();
            Users = userRepo.GetAll();

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
