using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using BluescreenSimulator.ViewModels;

namespace BluescreenSimulator.Views
{
    public partial class Windows11BlackScreenWindow : Window
    {
        private readonly Windows11BluescreenViewModel _vm;
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private readonly Stopwatch _clock = new Stopwatch();
        private bool _allowClose;

        public Windows11BlackScreenWindow(Windows11BluescreenViewModel data)
        {
            _vm = data;
            DataContext = data;
            InitializeComponent();
            Cursor = data.ShowMouse ? Cursors.Arrow : Cursors.None;
            if (data.FullScreen)
            {
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
            }
            else
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResize;
                ShowInTaskbar = true;
                Width = 960; Height = 540;
            }
            StopCodeText.Text = "Stop code: " + data.StopCode + (string.IsNullOrWhiteSpace(data.HexCode) ? "" : " (" + data.HexCode + ")");
            FaultyDriverText.Text = string.IsNullOrWhiteSpace(data.FaultyDriver) ? "" : "What failed: " + data.FaultyDriver;
            Closing += OnClosing;
            Loaded += OnLoaded;
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += OnTick;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_vm.TextDelay > 0)
                {
                    MainContent.Visibility = Visibility.Hidden;
                    DiagnosticText.Visibility = Visibility.Hidden;
                    await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(_vm.TextDelay));
                    if (_allowClose) return;
                    MainContent.Visibility = Visibility.Visible;
                    DiagnosticText.Visibility = Visibility.Visible;
                }
                _clock.Start();
                _timer.Start();
            }
            catch (System.Threading.Tasks.TaskCanceledException) { CloseSafely(); }
        }

        private void OnTick(object sender, EventArgs e)
        {
            var elapsed = _clock.Elapsed.TotalSeconds;
            var progress = Math.Min(100, (int)(elapsed / Math.Max(1, _vm.ProgressDuration) * 100));
            ProgressText.Text = progress + "% complete";
            if (_vm.AutoClose && elapsed >= _vm.AutoCloseSeconds) CloseSafely();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F7 || e.Key == Key.Escape)
            {
                e.Handled = true;
                CloseSafely();
            }
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (!_allowClose && _vm.FullScreen) e.Cancel = true;
            if (!e.Cancel) _timer.Stop();
        }

        private void CloseSafely()
        {
            if (_allowClose) return;
            _allowClose = true;
            _timer.Stop();
            Close();
        }
    }
}
