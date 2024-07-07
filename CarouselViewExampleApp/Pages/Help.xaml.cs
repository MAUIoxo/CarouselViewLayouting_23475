namespace CarouselViewExampleApp.Pages;

public partial class Help : ContentPage
{
	public Help()
	{
		InitializeComponent();
	}

    private void HelpPageBorder_SizeChanged(object sender, EventArgs e)
    {
		var border = (Border)sender;
		if (border?.Height > 0)
		{
            HelpTopicsScrollView.HeightRequest = border.Height - 75;
        }        
    }
}