namespace CarouselViewExampleApp.Pages.HelpPages
{
    public partial class ManageItemsHelpPage : ContentPage
    {
        public static readonly BindableProperty CarouselViewItemHeightProperty = BindableProperty.Create(nameof(CarouselViewItemHeight), typeof(double), typeof(ManageItemsHelpPage), 0.0);
        public static readonly BindableProperty CarouselViewItemWidthProperty = BindableProperty.Create(nameof(CarouselViewItemWidth), typeof(double), typeof(ManageItemsHelpPage), 0.0);

        public double CarouselViewItemHeight
        {
            get => (double)GetValue(CarouselViewItemHeightProperty);
            set => SetValue(CarouselViewItemHeightProperty, value);
        }
        
        public double CarouselViewItemWidth
        {
            get => (double)GetValue(CarouselViewItemWidthProperty);
            set => SetValue(CarouselViewItemWidthProperty, value);
        }


        public ManageItemsHelpPage()
        {
            InitializeComponent();
        }

        private void HelpPageBorder_SizeChanged(object sender, EventArgs e)
        {
            if (HelpPageBorder.Height > 0)
            {
                CarouselViewItemHeight = HelpPageBorder.Height - 50;
            }

            if (HelpPageBorder.Width > 0)
            {
                CarouselViewItemWidth = HelpPageBorder.Width;
            }
        }

        private void MaxSizeAspectRatioContainer_SizeChanged(object sender, EventArgs e)
        {
            var frame = sender as Frame;
            if (frame != null)
            {
                var image = frame.Content as Image;
                if (image != null)
                {
                    double size = 220d; // Math.Min(frame.Width, frame.Height);
                    size = Math.Min(size, 800); // Set max size to 800

                    image.WidthRequest = size;
                    image.HeightRequest = size;

                    frame.WidthRequest = size;
                    frame.HeightRequest = size;

                    image.MaximumWidthRequest = size;
                    image.MaximumHeightRequest = size;

                    frame.MaximumWidthRequest = size;
                    frame.MaximumHeightRequest = size;

                    this.ChangeVisualState();
                    this.InvalidateMeasure();
                    this.ForceLayout();
                }
            }
        }
    }
}
