using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ColorBlocks
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }



        public static Color defineColor()
        {
            Random rand1 = new Random();
            int value = rand1.Next(1, 5 + 1);
            switch (value)
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Blue;
                case 3:
                    return Color.Green;
                case 4:
                    return Color.Yellow;
                case 5:
                    return Color.Cyan;
                default:
                    Console.WriteLine("Error");
                    return Color.Black;
            }
        }
    }
}
