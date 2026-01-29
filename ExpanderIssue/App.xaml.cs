using Microsoft.UI.Xaml;
using System.Diagnostics;

namespace ExpanderIssue;

public partial class App : Application
{
    private Window? _window;

    public App()
    {
        InitializeComponent();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        EnableXamlDebugSettings();
        _window = new MainWindow();
        _window.Activate();
    }

    [Conditional("DEBUG")]
    private void EnableXamlDebugSettings()
    {
        try
        {
            DebugSettings.IsXamlResourceReferenceTracingEnabled = true;
            DebugSettings.XamlResourceReferenceFailed += (DebugSettings sender, XamlResourceReferenceFailedEventArgs args) =>
            {
                Debug.Assert(false, $"XAML resource lookup failed. Type={args.GetType()}, Message={args.Message}");
            };

            DebugSettings.IsBindingTracingEnabled = true;
            DebugSettings.BindingFailed += (object sender, BindingFailedEventArgs args) =>
            {
                Debug.Assert(false, $"XAML binding failed. Type={args.GetType()}, Message={args.Message}");
            };

            DebugSettings.LayoutCycleDebugBreakLevel = LayoutCycleDebugBreakLevel.High;
            DebugSettings.LayoutCycleTracingLevel = LayoutCycleTracingLevel.High;
            DebugSettings.EnableFrameRateCounter = false;
            DebugSettings.IsTextPerformanceVisualizationEnabled = false;
        }
        catch { }
    }
}
