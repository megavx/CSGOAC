using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
namespace CSGOAC_Server
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            Mutex _Mutex = new Mutex(true, "EAC_SERVERPROGRAM", out createdNew);
            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var main = new MainForm();
                main.FormClosed += new FormClosedEventHandler(FormClosed);
                main.Show();
                Application.Run();
                _Mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Already Running", "Warning");
                return;
            }
        }

        static void FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= FormClosed;
            if (Application.OpenForms.Count == 0) Application.ExitThread();
            else Application.OpenForms[0].FormClosed += FormClosed;
        }
    }
}
