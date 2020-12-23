using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetPictue
{
    static class Program
    {
        public static FlowLayoutPanel FlowLayoutPanel;
        static int[] photos = new int[10];
        public static int[] PositionPhotos = new int[40];

        public static void GeneratePhotos()
        {
            bool flag = false;
            Random r = new Random();
            int n = 0;

            for (int i = 0; i < 40; i++)
            {

                while (!flag)
                {
                    n = r.Next(0, 10);

                    if (photos[n] < 4)
                    {
                        photos[n]++;
                        flag = true;
                    }

                }

                flag = false;
                PositionPhotos[i] = n;
            }
        }

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new home());
        }
    }
}
