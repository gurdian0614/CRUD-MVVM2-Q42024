using CRUD_MVVM2_Q42024.Views;

namespace CRUD_MVVM2_Q42024
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new ProductoMainView()));
        }
    }
}