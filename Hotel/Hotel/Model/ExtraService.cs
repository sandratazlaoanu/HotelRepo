using System;

namespace Hotel.Model
{
    public class ExtraService
    {
        private int id;
        private String type;
        private float price;

        public ExtraService(int id, String type, float price)
        {
            this.id = id;
            this.type = type;
            this.price = price;
        }

        public int Id { get => id; set => id = value; }
        public float Price { get => price; set => price = value; }
        public String Type { get => type; set => type = value; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is ExtraService)
            {
                ExtraService st = obj as ExtraService;
                return Id == st.Id;
            }
            return false;
        }

        public static bool operator ==(ExtraService t1, ExtraService t2)
        {
            return t1.Id == t2.Id;
        }

        public static bool operator !=(ExtraService t1, ExtraService t2)
        {
            return t1.Id != t2.Id;
        }

        public override string ToString()
        {
            return string.Format("Extra stuff: {0} {1}", this.Type, this.Price);
        }

    }
}
