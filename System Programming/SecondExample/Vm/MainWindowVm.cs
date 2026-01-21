using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SecondExample.Vm;

public class MainWindowVm : INotifyPropertyChanged
{
    public int Argument { get; set; }

    private decimal result;
    public decimal Result 
    {
        get
        {
            return result;
        }
        set
        {
            result = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand CalculateCommand { get; }

    public MainWindowVm()
    {
        CalculateCommand = new (CalculateSum);
    }

    public void CalculateSum(object? parametr)
    {
        var thread = new Thread(() => 
        {
            decimal sum = 0;

            for (int i = 1; i < Argument; i++)
            {
                sum += i;
            }

            Result = sum;
        });

        thread.Start();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string nameProperty = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
    }
}
