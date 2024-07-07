using CommunityToolkit.Mvvm.ComponentModel;

namespace CarouselViewExampleApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public string mainPageTitle;        


        private byte _selectedViewModelIndex;
        public byte SelectedViewModelIndex
        {
            get => _selectedViewModelIndex;
            set
            {
                _selectedViewModelIndex = value;
            }
        }


        public MainPageViewModel()
        {
            MainPageTitle = "Calculate View";

            SelectedViewModelIndex = 0;
        }
    }
}
