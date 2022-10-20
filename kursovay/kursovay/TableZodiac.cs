using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace kursovay
{
    public partial class TableZodiac : Form
    {
        List<Person> people = new List<Person>();
        public TableZodiac(List<Person> people)
        {
            InitializeComponent();
            this.people = people; 
        }

        private void TableZodiac_Load(object sender, EventArgs e)
        {
            foreach (var item in people)
            {
                dataGridView1.Rows.Add(item.Name, item.Phone, item.Birthday[0].ToString() + '.' + item.Birthday[1].ToString() + '.' + item.Birthday[2].ToString(), item.Zodiac);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
