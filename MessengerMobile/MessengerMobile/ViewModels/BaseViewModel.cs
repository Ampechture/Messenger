using System.ComponentModel;
using System.Runtime.CompilerServices;
using MessengerMobile.Annotations;

namespace MessengerMobile.ViewModels;

internal class BaseViewModel
{
    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}