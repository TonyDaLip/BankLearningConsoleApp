using Timer = System.Timers.Timer;

namespace Bank2Solution.Application.Processing
{
    internal class TimeManager
    {
        private Timer _timer;

        public event Action<int> OnTimeAdvanced;

        public DateTime CurrentTime { get; private set; } = DateTime.Now;

        public void AdvanceTime(int months)
        {
            CurrentTime = CurrentTime.AddMonths(months);
            OnTimeAdvanced?.Invoke(months);
        }

        public void StartSimulation(int monthsPerMinute)
        {
            _timer = new Timer(60000 / monthsPerMinute);
            _timer.Elapsed += (sender, e) => AdvanceTime(1);
            _timer.Start();
        }

        public void StopSimulation()
        {
            _timer.Stop();
        }
    }
}
