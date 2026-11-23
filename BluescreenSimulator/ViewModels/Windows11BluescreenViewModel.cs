using BluescreenSimulator.Views;

namespace BluescreenSimulator.ViewModels
{
    [BluescreenView(typeof(Windows11BlackScreenWindow))]
    [CmdParameter("--win11", Description = "Uses the Windows 11 24H2+ black stop-error screen.")]
    public class Windows11BluescreenViewModel : BluescreenViewModelBase<Windows11Bluescreen>
    {
        public override string StyleName => "Windows 11 Black (24H2+)";
        public Windows11BluescreenViewModel() : this(null) { }
        public Windows11BluescreenViewModel(Windows11Bluescreen model = null) : base(model) { }

        [CmdParameter("-m", FullAlias = "message", Description = "Main restart message")]
        public string Message { get => Model.Message; set => SetModelProperty(value); }
        [CmdParameter("-sc", FullAlias = "stop-code", Description = "Stop code text")]
        public string StopCode { get => Model.StopCode; set => SetModelProperty(value); }
        [CmdParameter("-hx", FullAlias = "hex-code", Description = "Hexadecimal stop code")]
        public string HexCode { get => Model.HexCode; set => SetModelProperty(value); }
        [CmdParameter("-fd", FullAlias = "faulty-driver", Description = "Faulty driver/module name")]
        public string FaultyDriver { get => Model.FaultyDriver; set => SetModelProperty(value); }
        [CmdParameter("-td", FullAlias = "text-delay", Description = "Delay before text appears, seconds")]
        public double TextDelay { get => Model.TextDelay; set => SetModelProperty(System.Math.Max(0, System.Math.Min(value, 3600))); }
        [CmdParameter("-pd", FullAlias = "progress-duration", Description = "Progress duration, seconds")]
        public double ProgressDuration { get => Model.ProgressDuration; set => SetModelProperty(System.Math.Max(1, System.Math.Min(value, 3600))); }
        public bool ShowMouse { get => Model.ShowMouse; set => SetModelProperty(value); }
        public bool FullScreen { get => Model.FullScreen; set => SetModelProperty(value); }
        public bool AutoClose { get => Model.AutoClose; set => SetModelProperty(value); }
        public double AutoCloseSeconds { get => Model.AutoCloseSeconds; set => SetModelProperty(System.Math.Max(1, System.Math.Min(value, 86400))); }
    }
}
