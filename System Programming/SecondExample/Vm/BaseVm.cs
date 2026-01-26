using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SecondExample.Vm;

public class BaseVm : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string nameProperty = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
    }
}
