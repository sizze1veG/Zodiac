using System;

namespace kursovay
{
    public struct Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private int[] birthday;

        public int[] Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        private string zodiac;

        public string Zodiac
        {
            get { return zodiac; }
            set { zodiac = value; }
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}", name, phone, birthday, zodiac);
        }
    }
}
