using System;

namespace Hotel.Model
{
    class Room
    {
        private int id;
        private String type;
        private bool isAvailable;
        private float standardPrice;

        public Room(int id, String type, bool isAvailable, float stdPrice)
        {
            this.id = id;
            this.type = type;
            this.isAvailable = isAvailable;
            this.standardPrice = stdPrice;
        }

        public int Id { get => id; set => id = value; }
        public float StandardPrice { get => standardPrice; set => standardPrice = value; }
        public String Type { get => type; set => type = value; }
        public bool IsAvailable { get => isAvailable; set => isAvailable = value; }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Room)
            {
                Room st = obj as Room;
                return Id == st.Id;
            }
            return false;
        }

        public static bool operator == (Room t1, Room t2)
        {
            return t1.Id == t2.Id;
        }

        public static bool operator !=(Room t1, Room t2)
        {
            return t1.Id != t2.Id;
        }

        public override string ToString()
        {
            return string.Format("Room: {0} {1}", this.Type, this.StandardPrice);
        }

        public string ToWriteString()
        {
            return string.Format("{0} {1} {2}", this.id, this.Type, this.StandardPrice);
        }
    }
}
