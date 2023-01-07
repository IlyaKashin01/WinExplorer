namespace Explorer.Shared.ViewModels
{
    public class FileViewModel : FileEntityViewModel
    {
     
        public FileViewModel(string fileName) : base(fileName)
        {
        }

        public FileViewModel(FileInfo file) : base(file.Name)
        {
            FullName = file.FullName;
        }
    }
}
