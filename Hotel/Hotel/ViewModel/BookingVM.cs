using Hotel.Model;
using Hotel.Property;
using Hotel.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hotel.ViewModel
{
    class BookingVM : BasePropertyChanged
    {
        private BookingRepository repo = new BookingRepository();
        private ObservableCollection<Booking> bookings;
        public BookingVM()
        {
            this.bookings = ReturnCollection();
        }

        private string price;

        public string Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
                NotifyPropertyChanged("Price");
            }
        }

       private DateTime start;

       public DateTime Start
        {
            get
            {
                return this.start;
            }
            set
            {
                this.start = value;
                NotifyPropertyChanged("Start");
            }
        }

        private bool isActive;

        public bool IsActive
        {
            get
            {
                return this.isActive;
            }
            set
            {
                this.isActive = value;
                NotifyPropertyChanged("IsActive");
            }
        }

        private DateTime end;

        public DateTime End
        {
            get
            {
                return this.end;
            }
            set
            {
                this.end = value;
                NotifyPropertyChanged("End");
            }
        }
        public ObservableCollection<Booking> ReturnCollection()
        {
            var list = new List<Booking>();
            list = repo.GetAll();
            var oc = new ObservableCollection<Booking>();
            foreach (var item in list)
            {
                oc.Add(item);
            }

            return oc;
        }
        public ObservableCollection<Booking> Bookings  
        {
            get
            {
                return ReturnCollection();
            }
            set
            {
                this.bookings = ReturnCollection();
            }
        }
    }
      
}
