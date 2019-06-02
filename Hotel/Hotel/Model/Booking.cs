using System;
using System.Collections.Generic;

namespace Hotel.Model
{
    public class Booking
    {
        private int id;
        private DateTime start;
        private DateTime end;
        private Room room;
        private bool isActive;
        private float price;
        private List<ExtraService> services;

        public int Id { get => id; set => id = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
        public Room Room { get => room; set => room = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public float Price { get => price; set => price = value; }
        public List<ExtraService> Services { get => services; set => services = value; }

        public Booking(int id, DateTime start, DateTime end, float price)
        {
            this.id = id;
            this.start = start;
            this.end = end;
            this.isActive = true;
            this.price = price;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Booking)
            {
                Booking st = obj as Booking;
                return Id == st.Id;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("Booking: {0} {1} {2} {3}", this.Room, this.start.ToString(), this.end.ToString(), this.Price );
        }
    }

}

