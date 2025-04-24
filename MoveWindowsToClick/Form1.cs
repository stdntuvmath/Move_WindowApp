using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace MoveWindow
{
    public partial class Form1 : Form
    {
        /* [DllImport("user32.dll")]
         [return: MarshalAs(UnmanagedType.Bool)]
         static extern bool SetForegroundWindow(IntPtr hWnd);*/

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            const short SWP_NOMOVE = 0X2;
            const short SWP_NOSIZE = 1;
            const short SWP_NOZORDER = 0X4;
            const int SWP_SHOWWINDOW = 0x0040;

            Process[] processes = Process.GetProcesses();

            foreach (var process in processes)
            {

                IntPtr handle = process.MainWindowHandle;
                if (handle != IntPtr.Zero)
                {
                    SetWindowPos(handle, 0, 0, 0, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
                }



            }

            this.Close();
        }

    }
}

