using Microsoft.UI.Xaml;
using System.Collections.ObjectModel;
using Windows.Devices.Enumeration;

namespace ExpanderIssue;

public sealed partial class MainWindow : Window
{
    private readonly DeviceWatcher _watcher;

    public MainWindow()
    {
        InitializeComponent();
        // Just list some microphones...
        _watcher = DeviceInformation.CreateWatcher(DeviceClass.AudioCapture);
        _watcher.Added += OnAdded;
        _watcher.EnumerationCompleted += OnEnumerationCompleted;
        _watcher.Start();
    }

    private void OnEnumerationCompleted(DeviceWatcher sender, object args)
    {
        sender.Added -= OnAdded;
        sender.EnumerationCompleted -= OnEnumerationCompleted;
    }

    private void OnAdded(DeviceWatcher sender, DeviceInformation args)
    {
        DispatcherQueue.TryEnqueue(() => Microphones.Add(args));
    }

    public ObservableCollection<DeviceInformation> Microphones { get; } = [];
}
