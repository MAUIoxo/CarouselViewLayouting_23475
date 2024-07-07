using CarouselViewExampleApp.ViewModels;

namespace CarouselViewExampleApp.Pages;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel mainPageViewModel;
    private byte SelectedViewIndex { get; set; }
    
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();

        mainPageViewModel = viewModel;
        BindingContext = viewModel;
    }

    private View CreateTitleView()
    {
        var titleViewLabel = new Label
        {
            Text = mainPageViewModel.MainPageTitle
        };

        var horizontalStackLayout = new HorizontalStackLayout();
        horizontalStackLayout.Children.Add(titleViewLabel);

        return horizontalStackLayout;
    }

    private void UpdatePageTitleForSelectedView()
    {
        switch(SelectedViewIndex)
        {
            case 0:
                mainPageViewModel.MainPageTitle = "Calculate";
                break;

            case 1:
                mainPageViewModel.MainPageTitle = "Overview";
                break;
        }
    }

    protected override void OnAppearing()
    {
        Shell.SetTabBarIsVisible(this, false);
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
    }
}