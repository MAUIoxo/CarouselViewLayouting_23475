using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarouselViewExampleApp.ViewModels
{
    public partial class HelpViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject, INotifyPropertyChanged
    {
        public HelpViewModel()
        {
            
        }

        #region Search Filter

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;

                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }

        #endregion

        #region Eventing

        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        {
            add => weakEventManager.AddEventHandler(value);
            remove => weakEventManager.RemoveEventHandler(value);
        }

        private readonly Microsoft.Maui.WeakEventManager weakEventManager = new();

        void OnPropertyChanged([CallerMemberName] in string propertyName = "") => weakEventManager.HandleEvent(this, new PropertyChangedEventArgs(propertyName), nameof(INotifyPropertyChanged.PropertyChanged));

        #endregion
    }
}
