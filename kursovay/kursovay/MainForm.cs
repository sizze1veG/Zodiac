using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace kursovay
{
    public partial class MainForm : Form
    {
        List<Person> persons = new List<Person>();
        public MainForm()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            menuStrip1.BackColor = Color.Transparent;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo("Person.txt");
            if (file.Length != 0)
            {
                List<string[]> rows = File.ReadAllLines("Person.txt", Encoding.GetEncoding(1251)).Select(x => x.Split(',')).ToList();
                for (int i = 0; i < rows.Count; i++)
                {
                    Person person = new Person();
                    person.Name = rows[i][0];
                    person.Phone = rows[i][1];
                    string[] dateBirthday = rows[i][2].Split('.');
                    int[] numberBirthday = new int[3];
                    for (int j = 0; j < dateBirthday.Length; j++)
                    {
                        numberBirthday[j] = int.Parse(dateBirthday[j]);
                    }
                    person.Birthday = numberBirthday;
                    person.Zodiac = rows[i][3];
                    persons.Add(person);
                    dataGridView1.Rows.Add(rows[i]);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string phone = textBoxPhone.Text;
            string birthday = textBoxBirthday.Text;

            if (CheckName(name) && CheckPhone(phone) && CheckBirthday(birthday) && CheckRepeatName(name))
            {
                dataGridView1.Rows.Add(name, phone, birthday, GetZodiac(birthday));
                using (StreamWriter sw = new StreamWriter("Person.txt", false, Encoding.GetEncoding(1251)))
                {
                    for (int i = 0; i < Convert.ToInt32(dataGridView1.Rows.Count); i++)
                    {
                        sw.WriteLine(dataGridView1.Rows[i].Cells[0].Value.ToString() + "," + dataGridView1.Rows[i].Cells[1].Value.ToString() + "," + dataGridView1.Rows[i].Cells[2].Value.ToString() + "," + dataGridView1.Rows[i].Cells[3].Value.ToString());
                    }
                }
                List<string[]> rows = File.ReadAllLines("Person.txt", Encoding.GetEncoding(1251)).Select(x => x.Split(',')).ToList();
                Person person = new Person();
                int index = rows.Count-1;
                person.Name = rows[index][0];
                person.Phone = rows[index][1];
                string[] dateBirthday = rows[index][2].Split('.');
                int[] numberBirthday = new int[3];
                for (int j = 0; j < dateBirthday.Length; j++)
                {
                    numberBirthday[j] = int.Parse(dateBirthday[j]);
                }
                person.Birthday = numberBirthday;
                person.Zodiac = rows[index][3];
                persons.Add(person);
                MessageBox.Show("Данные добавлены!");
                textBoxName.Clear();
                textBoxPhone.Clear();
                textBoxBirthday.Clear();
            }
            else
            {
                if (!CheckName(name))
                {
                    MessageBox.Show("Имя задано некорректно!");
                }
                if (!CheckRepeatName(name))
                {
                    MessageBox.Show("Такое имя уже существует!");
                }
                if (!CheckPhone(phone))
                {
                    MessageBox.Show("Телефон введен некорректно!");
                }
                if (!CheckBirthday(birthday))
                {
                    MessageBox.Show("Дата рождения введена некорректно!");
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить данные?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    int index = dataGridView1.CurrentRow.Index;
                    int indexDGW = 0;
                    Person person = GetDGWIndex(ref index);
                    foreach (var item in persons)
                    {
                        if (item.Name == person.Name && item.Phone == person.Phone && item.Birthday == person.Birthday && item.Zodiac == person.Zodiac)
                        {
                            dataGridView1.Rows.RemoveAt(indexDGW);
                            break;
                        }
                        indexDGW++;
                    }
                    persons.RemoveAt(index);
                    using (StreamWriter sw = new StreamWriter("Person.txt", false, Encoding.GetEncoding(1251)))
                    {
                        for (int i = 0; i < Convert.ToInt32(dataGridView1.Rows.Count); i++)
                        {
                            sw.WriteLine(dataGridView1.Rows[i].Cells[0].Value.ToString() + "," + dataGridView1.Rows[i].Cells[1].Value.ToString() + ","
                                + dataGridView1.Rows[i].Cells[2].Value.ToString() + "," + dataGridView1.Rows[i].Cells[3].Value.ToString() + ",");
                        }
                    }
                }
                catch { }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string name = textBoxSearchName.Text;
            bool flag = false;
            foreach (var item in persons)
            {
                if (item.Name == name)
                {
                    flag = true;
                    SearchPerson form = new SearchPerson(item.Name, item.Phone, item.Birthday, item.Zodiac);
                    form.Show();
                    textBoxSearchName.Clear();
                }
            }
            if (!flag)
            {
                MessageBox.Show("Данные не найдены!");
                textBoxSearchName.Clear();
            }
        }

        private void buttonSearchZodiac_Click(object sender, EventArgs e)
        {
            string zodiac = textBoxSearchZodiac.Text;
            bool flag = false;
            List<Person> people = new List<Person>();
            foreach (var item in persons)
            {
                if (item.Zodiac == zodiac)
                {
                    flag = true;
                    people.Add(item);
                }
            }
            if (!flag)
            {
                MessageBox.Show("Данные не найдены!");
                textBoxSearchZodiac.Clear();
            }
            else
            {
                TableZodiac form = new TableZodiac(people);
                form.Show();
                textBoxSearchZodiac.Clear();
            }
        }

        private bool CheckName(string name)
        {
            if (name.Length < 6 || name.Length > 40)
            {
                return false;
            }
            foreach (var item in name)
            {
                if (!char.IsLetter(item) && !char.IsWhiteSpace(item))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckRepeatName(string name)
        {
            foreach (var item in persons)
            {
                if (item.Name == name)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckPhone(string phone)
        {
            if (phone.Length != 11)
            {
                return false;
            }
            foreach (var item in phone)
            {
                if (!char.IsNumber(item))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckBirthday(string birthday)
        {
            if (birthday.Length != 10)
            {
                return false;
            }
            if (birthday.ElementAt(2) != '.' || birthday.ElementAt(5) != '.')
            {
                return false;
            }
            for (int i = 0; i < 10; i++)
            {
                if (i == 2 || i == 5)
                {
                    continue;
                }
                else
                {
                    if (!char.IsNumber(birthday.ElementAt(i)))
                    {
                        return false;
                    }
                }
            }
            int day;
            string dayString = Convert.ToString(birthday.ElementAt(0)) + Convert.ToString(birthday.ElementAt(1));
            day = Convert.ToInt32(dayString);
            int month;
            string monthString = Convert.ToString(birthday.ElementAt(3)) + Convert.ToString(birthday.ElementAt(4));
            month = Convert.ToInt32(monthString);
            int year;
            string yearString = Convert.ToString(birthday.ElementAt(6)) + Convert.ToString(birthday.ElementAt(7)) + Convert.ToString(birthday.ElementAt(8)) + Convert.ToString(birthday.ElementAt(9));
            year = Convert.ToInt32(yearString);
            if (day > 31 || month > 12)
            {
                return false;
            }
            DateTime checkDate = new DateTime(year, month, day);
            DateTime today = DateTime.Now;
            if (checkDate > today)
            {
                return false;
            }
            return true;
        }

        private string GetZodiac(string birthday)
        {
            int day;
            string dayString = Convert.ToString(birthday.ElementAt(0))+Convert.ToString(birthday.ElementAt(1));
            day = Convert.ToInt32(dayString);
            int month;
            string monthString = Convert.ToString(birthday.ElementAt(3)) + Convert.ToString(birthday.ElementAt(4));
            month = Convert.ToInt32(monthString);
            switch (month)
            {
                case 1:
                    if (day <= 19)
                        return "Козерог";
                    else
                        return "Водолей";

                case 2:
                    if (day <= 18)
                        return "Водолей";
                    else
                        return "Рыбы";
                case 3:
                    if (day <= 20)
                        return "Рыбы";
                    else
                        return "Овен";
                case 4:
                    if (day <= 19)
                        return "Овен";
                    else
                        return "Телец";
                case 5:
                    if (day <= 20)
                        return "Телец";
                    else
                        return "Близнецы";
                case 6:
                    if (day <= 20)
                        return "Блтзнецы";
                    else
                        return "Рак";
                case 7:
                    if (day <= 22)
                        return "Рак";
                    else
                        return "Лев";
                case 8:
                    if (day <= 22)
                        return "Лев";
                    else
                        return "Дева";
                case 9:
                    if (day <= 22)
                        return "Дева";
                    else
                        return "Весы";
                case 10:
                    if (day <= 22)
                        return "Весы";
                    else
                        return "Скорпион";
                case 11:
                    if (day <= 21)
                        return "Скорпион";
                    else
                        return "Стрелец";
                case 12:
                    if (day <= 21)
                        return "Стрелец";
                    else
                        return "Козерог";
            }
            return "";
        }

        Person GetDGWIndex(ref int index)
        {
            Person person = new Person();
            for (int i = 0; i < persons.Count; i++)
            {
                if (i == index)
                {
                    person = persons.ElementAt(index);
                }
            }
            return person;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info form = new Info();
            form.Show();
        }

        private void textBoxSearchName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
