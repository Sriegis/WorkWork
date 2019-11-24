using Busylight;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WorkWork
{
    class Program
    {
        //private
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LowLevelKeyboardHook kbh = new LowLevelKeyboardHook();
            kbh.OnKeyPressed += kbh_OnKeyPressed;
            kbh.OnKeyUnpressed += kbh_OnKeyUnpressed;
            kbh.HookKeyboard();

            Application.Run();

            kbh.UnHookKeyboard();

        }

        private static void kbh_OnKeyUnpressed(object sender, Keys e)
        {
            // do nothing
            var busylight = new SDK(false);
            busylight.Light(BusylightColor.Off);
        }

        private static void kbh_OnKeyPressed(object sender, Keys e)
        {
            var random = new Random();
            var rnd1 = random.Next(256);
            var rnd2 = random.Next(256);
            var rnd3 = random.Next(256);
            var @switch = e == Keys.LWin;
            if (@switch)
            {
                var method = GetLightMethod();

            }

            var busylight = new SDK(false);
            //Light(busylight, red, blue, green);
        }

        private static void LightRB(ISDK busylight, int c1, int c2)
        {
            busylight.Light(c1, c2, 0);
        }

        private static void LightRG(ISDK busylight, int c1, int c2)
        {
            busylight.Light(c1, 0, c2);
        }

        private static void LightBG(ISDK busylight, int c1, int c2)
        {
            busylight.Light(0, c1, c2);
        }

        private static void Light(ISDK busylight, int red, int blue, int green)
        {
            busylight.Light(red, blue, green);
        }

        private static IEnumerable<Action<ISDK, int, int>> GetLightMethod()
        {
            yield return (x, y, z) => LightRB(x, y, z);
            yield return (x, y, z) => LightRG(x, y, z);
            yield return (x, y, z) => LightBG(x, y, z);
        }
    }
}