
namespace WishList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.MinimumWidth = 500;
            window.MinimumHeight = 500;
            return window;
        }
    }
}
