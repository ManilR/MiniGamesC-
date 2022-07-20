using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;



namespace MasterMind
{
    
    static class Program
    {
        private const int NB_TOURS_MAX = 8;

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


        public static Color[] goalColors = new Color[6];
        public static int nbTours = 0;

        public static void defineGoal(int nbBoutons)
        {
            Random rand1 = new Random();
            for (int i = 0; i < nbBoutons; i++)
            {
                int value = rand1.Next(1, nbBoutons+1);
                goalColors[i] = defineColor(value);
            }
        }

        public static Color defineColor(int value)
        {
            switch(value)
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
        public static Color changeColor(Color c)
        {
            int argb = c.ToArgb();
            switch (argb)
            {
                case -65536://red
                    return Color.Blue;
                case -16776961://blue
                    return Color.Green;
                case -16744448://green
                    return Color.Yellow;
                case -256://yellow
                    return Color.Cyan;
                case -16711681://cyn
                    return Color.Red;
            }


            return c;
        }

        public static int[] checkTry(Color[] tryColor, int nbBouton)
        {
            int[] goodTab = new int[4];
            int[] nbGoodnBadPlace = new int[2];
            bool[] isUsedTab = new bool[4];
            
            for(int i = 0; i < 4; i++)
            {
                if (tryColor[i] == goalColors[i])
                {
                    goodTab[i] = 2;
                    isUsedTab[i] = true;
                }  
            }

            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(tryColor[i] == goalColors[j] && !isUsedTab[j])
                    {
                        goodTab[i] = 1;
                        isUsedTab[j] = true;
                    }
                }

            }


            for (int i = 0; i < 4; i++)
            {
                if (goodTab[i] == 2)
                    nbGoodnBadPlace[0]++;
                else if(goodTab[i] == 1)
                    nbGoodnBadPlace[1]++;
            }

            return nbGoodnBadPlace;
        }

        public static bool checkDefeat()
        {
            return nbTours >= NB_TOURS_MAX;
        }
    }
}
