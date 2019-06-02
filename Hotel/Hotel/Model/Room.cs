using System;

namespace Hotel.Model
{
    public class Room
    {
        private int id;
        private String type;
        private bool isAvailable;
        private float standardPrice;
        private int v1;
        private string v2;
        private string v3;
        private string v4;

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
