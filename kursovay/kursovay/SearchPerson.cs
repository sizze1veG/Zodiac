using System;
using System.Drawing;
using System.Windows.Forms;

namespace kursovay
{
    public partial class SearchPerson : Form
    {
        public SearchPerson(string name, string phone, int[] birthday, string zodiac)
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label1.Text = name;
            label2.Text = phone;
            string strBirthday = Convert.ToString(birthday[0]) + "." + Convert.ToString(birthday[1]) + "." + Convert.ToString(birthday[2]);
            label3.Text = strBirthday;
            label4.Text = zodiac;
        }

        private void SearchPerson_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
