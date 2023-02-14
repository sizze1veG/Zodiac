using System;
using System.Windows.Forms;

namespace kursovay
{
    public delegate void MyDelegate(string data1, string data2, string data3, string data4);

    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }  
    }
    static class Data
    {
        public static string Value1 { get; set; }
        public static string Value2 { get; set; }
        public static string Value3 { get; set; }
        public static string Value4 { get; set; }
    }
}
