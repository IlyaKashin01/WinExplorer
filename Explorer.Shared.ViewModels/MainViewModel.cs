
using Explorer.Shared.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Explorer.WPF.UI
{
    public class MainViewModel : BaseViewModel
    {
        public string? FilePath { get; set; }
        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } = new ObservableCollection<FileEntityViewModel>();
        public FileEntityViewModel? SelectedFileEntity { get; set; }
        public ICommand OpenCommand { get { return new DelegateCommand(Open); } }

        public MainViewModel()
        {
            //OpenCommand = new DelegateCommand(Open);
            foreach (var logicalDrive in Directory.GetLogicalDrives())
            {
                DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
            }
            
        }


        private void Open(object parameter)
        {
            if (SelectedFileEntity is DirectoryViewModel directoryModel)
            {
                FilePath = directoryModel.Name;
                DirectoriesAndFiles.Clear();
                var directoryInfo = new DirectoryInfo(FilePath);

                foreach (var directory in directoryInfo.GetDirectories())
                {
                    DirectoriesAndFiles.Add(new DirectoryViewModel(directory.Name));
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    DirectoriesAndFiles.Add(new FileViewModel(file.Name));
                }
            }
        }
    }
}
