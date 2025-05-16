using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using static Vanara.PInvoke.WinMm;

namespace Dreams
{
    public class  ByteBeats
    {
        static SafeHWAVEOUT hWaveOut;
        public static void Bytebeat1()
        {
            WAVEFORMATEX wfx = new WAVEFORMATEX();
            const int hz = 16000;
            wfx.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_PCM;
            wfx.nSamplesPerSec = hz;
            wfx.nAvgBytesPerSec = hz;
            wfx.wBitsPerSample = 8;
            wfx.nBlockAlign = 1;
            wfx.nChannels = 1;
            wfx.cbSize = 0;
            const uint MAPPER = 0xFFFFFFFF;
            waveOutOpen(out hWaveOut, MAPPER, in wfx, IntPtr.Zero, IntPtr.Zero, WAVE_OPEN.CALLBACK_NULL);
            byte[] sbuffer = new byte[16000 * 1600];
            for (int t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)(t + (t >> 10 | t / 20));
            }
            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);
            WAVEHDR header = new WAVEHDR();
            header.lpData = handle.AddrOfPinnedObject();
            header.dwBufferLength = (uint)sbuffer.Length;
            header.dwFlags = 0;
            header.dwLoops = 0;

            waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadAbortException)
            {
                waveOutReset(hWaveOut);
                waveOutClose(hWaveOut);
                handle.Free();
            }
        }
        public static void Bytebeat2()
        {
            WAVEFORMATEX wfx = new WAVEFORMATEX();
            const int hz = 48000;
            wfx.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_PCM;
            wfx.nSamplesPerSec = hz;
            wfx.nAvgBytesPerSec = hz;
            wfx.wBitsPerSample = 8;
            wfx.nBlockAlign = 1;
            wfx.nChannels = 1;
            wfx.cbSize = 0;
            const uint MAPPER = 0xFFFFFFFF;
            waveOutOpen(out hWaveOut, MAPPER, in wfx, IntPtr.Zero, IntPtr.Zero, WAVE_OPEN.CALLBACK_NULL);
            byte[] sbuffer = new byte[16000 * 1600];
            for (uint t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)(t * (42 & t >> 5));
            }
            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);
            WAVEHDR header = new WAVEHDR();
            header.lpData = handle.AddrOfPinnedObject();
            header.dwBufferLength = (uint)sbuffer.Length;
            header.dwFlags = 0;
            header.dwLoops = 0;

            waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadAbortException)
            {
                waveOutReset(hWaveOut);
                waveOutClose(hWaveOut);
                handle.Free();
            }
        }
        public static void Bytebeat3()
        {
            WAVEFORMATEX wfx = new WAVEFORMATEX();
            const int hz = 15360;
            wfx.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_PCM;
            wfx.nSamplesPerSec = hz;
            wfx.nAvgBytesPerSec = hz;
            wfx.wBitsPerSample = 8;
            wfx.nBlockAlign = 1;
            wfx.nChannels = 1;
            wfx.cbSize = 0;
            const uint MAPPER = 0xFFFFFFFF;
            waveOutOpen(out hWaveOut, MAPPER, in wfx, IntPtr.Zero, IntPtr.Zero, WAVE_OPEN.CALLBACK_NULL);
            byte[] sbuffer = new byte[16000 * 1600];
            for (int t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)(t * ((0xAFEDC320 >> t / (6 - (t >> 10 & 13)) & 1) != 0 ? 128 : 0));
            }
            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);
            WAVEHDR header = new WAVEHDR();
            header.lpData = handle.AddrOfPinnedObject();
            header.dwBufferLength = (uint)sbuffer.Length;
            header.dwFlags = 0;
            header.dwLoops = 0;

            waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadAbortException)
            {
                waveOutReset(hWaveOut);
                waveOutClose(hWaveOut);
                handle.Free();
            }
        }
        public static void Bytebeat4()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX();
                const int HZ = 8000;
                wfx.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_PCM;
                wfx.nSamplesPerSec = HZ;
                wfx.nAvgBytesPerSec = HZ;
                wfx.wBitsPerSample = 8;
                wfx.nBlockAlign = 1;
                wfx.nChannels = 1;
                wfx.cbSize = 0;
                const uint MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, MAPPER, in wfx, IntPtr.Zero, IntPtr.Zero, WAVE_OPEN.CALLBACK_NULL);

                byte[] sbuffer = new byte[16000 * 1660];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    int value = (t * t * 4) / ((5656 >> (t >> 12 & 14) & 7) + 9);
                    value *= (t >> 10 & 893);
                    value &= (t >> 4) ^ (((t >> 16 & 1) == 0 ? 0 : (t >> 10 & -t >> 14 & 3)) | ((t >> 9 & 1) + (t >> 12 & 7) == 0 ? 9001 / ((t % 4096) + 1) - t / 9 & 8 : 0));


                    sbuffer[t] = (byte)(value);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

                WAVEHDR header = new WAVEHDR();
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                    waveOutClose(hWaveOut);
                    handle.Free();
                }
            }
        }
    }
}
