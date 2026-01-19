using System.Diagnostics;
using System.Windows;

namespace FirstApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Process? childProcess;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click_CreateChildProcess(object sender, RoutedEventArgs e)
    {
        childProcess = Process.Start(@"C:\Users\artem\source\repos\System Programming\System Programming\SecondApp\bin\Debug\net10.0-windows\SecondApp.exe");
    }

    private void Button_Click_KillChildProcess(object sender, RoutedEventArgs e)
    {
        childProcess?.Kill();
    }
}