using System.Windows.Media;

namespace BluescreenSimulator
{
    public class Windows11Bluescreen : BluescreenBase
    {
        public string Message { get; set; } = "Your device ran into a problem and needs to restart.";
        public string StopCode { get; set; } = "CRITICAL_PROCESS_DIED";
        public string HexCode { get; set; } = "0xEF";
        public string FaultyDriver { get; set; } = "rdbyss.sys";
        public double TextDelay { get; set; } = 0;
        public double ProgressDuration { get; set; } = 12;
        public bool ShowMouse { get; set; } = false;
        public bool FullScreen { get; set; } = true;
        public bool AutoClose { get; set; } = false;
        public double AutoCloseSeconds { get; set; } = 20;
        public Windows11Bluescreen()
        {
            BackgroundColor = Colors.Black;
            ForegroundColor = Color.FromRgb(245, 245, 245);
        }
    }
}
