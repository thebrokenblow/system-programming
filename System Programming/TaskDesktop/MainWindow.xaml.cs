using System.IO;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace TaskDesktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        using var streamReader = new StreamReader("C:\\Users\\artem\\OneDrive\\Рабочий стол\\numbers.txt");
        var result = new List<string>();
        while (true)
        {
            var strNumber = await streamReader.ReadLineAsync();

            if (strNumber == null)
            {
                break;
            }

            var number = Convert.ToInt32(strNumber);

            if (IsPrimeNumber(number))
            {
                result.Add(strNumber);
            }
        }

        await File.WriteAllLinesAsync("C:\\Users\\artem\\OneDrive\\Рабочий стол\\result.txt", result);
    }

    private static bool IsPrimeNumber(int number)
    {
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}