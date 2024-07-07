using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CarouselViewExampleApp.ViewModels
{
    public class ManageItemsHelpPageViewModel
    {
        public ObservableCollection<CarouselItem> Items { get; set; }

        public ManageItemsHelpPageViewModel()
        {
            Items = new ObservableCollection<CarouselItem>
            {
                new CarouselItem
                {
                    Image = "dotnet_bot.png",
                    Title = "Add Items",
                    Description = "Description how to add items"
                },
                new CarouselItem
                {
                    Image = "dotnet_bot_2.png",
                    Title = "Edit Items",
                    Description = "Description how to edit items"
                }
            };
        }
    }

    public class CarouselItem : INotifyPropertyChanged
    {
        private string image;
        private string title;
        private string description;

        public string Image
        {
            get => image;
            set
            {
                if (image != value)
                {
                    image = value;
                    OnPropertyChanged(nameof(Image));
                }
            }
        }

        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
