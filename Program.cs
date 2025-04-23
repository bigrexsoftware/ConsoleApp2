using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("user32.dll")]
    static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
    private const int MOUSEEVENTF_MOVE = 0x0001;
    private const int MOUSEEVENTF_WHEEL = 0x0800;

    // dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

    static void Main(string[] args)
    {
        //Console.WriteLine("Started. Press ENTER to stop.");

        bool keepRunning = true;

        while (keepRunning)
        {
            Move();
            Scroll(1); //up
            Scroll(-1); //down

            Thread.Sleep(180000);

            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter)
                {
                    keepRunning = false;
                }
            }
        }

        //Console.WriteLine("Stopped.");
    }

    static void Move()
    {
        mouse_event(MOUSEEVENTF_MOVE, 1, 1, 0, 0);
        mouse_event(MOUSEEVENTF_MOVE, -1, -1, 0, 0);
    }

    static void Scroll(int scrollAmount)
    {
        mouse_event(MOUSEEVENTF_WHEEL, 0, 0, scrollAmount, 0);
    }


}