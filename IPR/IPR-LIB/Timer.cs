using System.Threading;

namespace IPR_LIB
{
    public class Timer
    {
        public int sec { get; private set; }
        public int min { get; private set; }
        private Thread timerThread;

        public Timer()
        {
            sec = 0;
            min = 0;
        }

        public void StartTimer()
        {
            timerThread = new Thread(new ThreadStart(DoWork));
        }

        private void DoWork()
        {
            while (true)
            {
                if (sec > 59)
                {
                    sec = 0;
                    min++;
                }
                else
                {
                    sec++;
                }
                Thread.Sleep(1000);
            }
        }
        public string GetTime()
        {
            if (min > 9 & sec > 9) return $"{min}:{sec}";
            else if (min < 9 & sec > 9) return $"0{min}:{sec}";
            else if (min < 9 & sec < 9) return $"0{min}:0{sec}";
            else return $"{min}:0{sec}";
        }
        public void Reset()
        {
            sec = 0;
            min = 0;
        }

        public void Stop()
        {
            timerThread.Abort();
        }
    }
}
