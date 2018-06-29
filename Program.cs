using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace winformTest
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                using (Form1 form = new Form1())
                using (GameManager game = GameManager.Get)
                {
                    if (game.Init(form))
                    {
                        form.Show();

                        while (form.Created)
                        {
                            game.Update();
                            game.Render();
                            System.Threading.Thread.Sleep(10);
                            Application.DoEvents();
                        }
                    }
                    else throw new Exception("Error!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
