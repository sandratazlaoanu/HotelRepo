using Hotel.Model;
using Hotel.Property;
using Hotel.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hotel.ViewModel
{
    public class RoomVM : BasePropertyChanged
    {
        private RoomRepository repo = new RoomRepository();
        private ObservableCollection<Room> rooms;
        public RoomVM()
        {
            this.rooms = ReturnCollection();
        }

        private string standardPrice;

        public string StandardPrice
        {
            get
            {
                return this.standardPrice;
            }
            set
            {
                this.standardPrice = value;
                NotifyPropertyChanged("StandardPrice");
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

        public ObservableCollection<Room> ReturnCollection()
        {
            var list = new List<Room>();
            list = repo.GetAll();
            var oc = new ObservableCollection<Room>();
            foreach (var item in list)
            {
                oc.Add(item);
            }

            return oc;
        }
        public ObservableCollection<Room> Rooms { get => rooms; set => rooms = ReturnCollection(); }

       
    }
}
