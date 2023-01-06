
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Explorer.WPF.UI
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Constructor
        public MainViewModel()
        {
            MainDiskName = Environment.SystemDirectory;
        }
        #endregion

        #region Public Properties
        public string MainDiskName { get; set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Protected methods
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
