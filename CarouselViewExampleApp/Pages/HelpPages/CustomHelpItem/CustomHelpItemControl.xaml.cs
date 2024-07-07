using CommunityToolkit.Mvvm.Input;

namespace CarouselViewExampleApp.Pages.Views.Controls.CustomHelpItem
{
    public partial class CustomHelpItemControl : ContentView
    {
        public static readonly BindableProperty HelpTopicProperty = BindableProperty.Create(nameof(HelpTopic), typeof(string), typeof(CustomHelpItemControl), default(string), BindingMode.TwoWay);
        public static readonly BindableProperty HelpPageProperty = BindableProperty.Create(nameof(HelpPage), typeof(Type), typeof(CustomHelpItemControl), default(Type), BindingMode.TwoWay);
        public static readonly BindableProperty RippleColorProperty = BindableProperty.Create(nameof(RippleColor), typeof(Color), typeof(CustomHelpItemControl), default(Color), BindingMode.TwoWay);

        public string HelpTopic
        {
            get => (string)GetValue(HelpTopicProperty);
            set => SetValue(HelpTopicProperty, value);
        }

        public Type HelpPage
        {
            get => (Type)GetValue(HelpPageProperty);
            set => SetValue(HelpPageProperty, value);
        }

        public Color RippleColor
        {
            get => (Color)GetValue(RippleColorProperty);
            set => SetValue(RippleColorProperty, value);
        }

        private Frame ripple;
        private bool _hapticFeedbackTriggered;
        

        public CustomHelpItemControl()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private async void OnGridTapped(object sender, EventArgs e)
        {
            var grid = (Grid)sender;
            StartRippleEffect(grid);

            Task.Delay(500); // Wait for animation to finish

            if (!_hapticFeedbackTriggered)
            {
                await NavigateToHelpPageAsync();
            }

            // HapticFeedback was triggered, so we have to delete it
            _hapticFeedbackTriggered = false;

            ClearRippleEffect(grid);
        }

        [RelayCommand]
        private void OnLongPressStarted(Grid grid)
        {
            _hapticFeedbackTriggered = false;

            StartRippleEffect(grid);
        }

        [RelayCommand]
        private void OnLongPress(Grid grid)
        {
            _hapticFeedbackTriggered = true;

            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
            
            ClearRippleEffect(grid);
        }        

        private void StartRippleEffect(Grid grid)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (ripple != null)
                {
                    grid.Children.Remove(ripple);
                }

                ripple = CreateRippleFrame(grid);
                grid.Children.Add(ripple);

                var animation = new Animation(v => { if (ripple != null) ripple.Opacity = v; }, 0, 1, Easing.SinOut);
                animation.Commit(ripple, "RippleAnimation", 16, 250);
            });
        }

        private void ClearRippleEffect(Grid grid)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (ripple != null)
                {
                    grid.Children.Remove(ripple);
                    ripple = null;
                }
            });
        }

        private Frame CreateRippleFrame(Grid grid)
        {
            return new Frame
            {
                Background = new LinearGradientBrush
                {
                    StartPoint = new Point(0, 0.0),
                    EndPoint = new Point(1, 0.0),
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop { Color = Colors.Transparent, Offset = 0.0f },
                        new GradientStop { Color = RippleColor.MultiplyAlpha(0.5f), Offset = 0.1f },
                        new GradientStop { Color = RippleColor.MultiplyAlpha(0.5f), Offset = 0.9f },
                        new GradientStop { Color = Colors.Transparent, Offset = 1.0f }
                    }
                },
                CornerRadius = 0,
                BorderColor = Colors.Transparent,
                Opacity = 0.0,
                WidthRequest = grid.Width,
                HeightRequest = grid.Height,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
        }

        private async Task NavigateToHelpPageAsync()
        {
            var page = (ContentPage)Activator.CreateInstance(HelpPage);
            if (page != null)
            {
                await Navigation.PushAsync(page);
            }
        }
    }
}
