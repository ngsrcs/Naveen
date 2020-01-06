using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reflection;
using log4net;

namespace NaveenWPFApp.ViewModels
{
    internal abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
