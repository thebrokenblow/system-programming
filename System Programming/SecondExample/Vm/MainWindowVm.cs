using SecondExample.Model;
using System.Windows;

namespace SecondExample.Vm;

public class MainWindowVm : BaseVm
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
    public RelayCommand CancelCalculateCommand { get; }

    private bool isEnabled;
    public bool IsEnabled 
    {
        get
        {
            return isEnabled;
        }
        set
        {
            isEnabled = value;
            
            OnPropertyChanged();

            CalculateCommand.RaiseCanExecuteChanged();
            CancelCalculateCommand.RaiseCanExecuteChanged();
        }
    }

    private readonly Action<string> _messageWindow;

    private CancellationTokenSource? cancellationTokenSource;
    public MainWindowVm(Action<string> messageWindow)
    {
        _messageWindow = messageWindow;
        
        CalculateCommand = new (CalculateSum, _ => !IsEnabled);
        CancelCalculateCommand = new(_ => cancellationTokenSource?.Cancel(), _ => IsEnabled);
    }

    private void GetSum(decimal result)
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            Result = result;
        });
    }

    private void CalculateSum(object? parametr)
    {
        IsEnabled = true;

        cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;

        var thread = new Thread(() => 
        {
            try
            {
                MyMath.GetSum(Argument, GetSum, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Result = 0;
                _messageWindow.Invoke("Задача отменена");
            }
            catch (Exception)
            {
                _messageWindow.Invoke("Произошла ошибка вычислений");
            }
            finally
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    IsEnabled = false;
                });
            }
        });

        thread.Start();
    }
}