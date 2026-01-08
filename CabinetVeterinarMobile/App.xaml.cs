using Microsoft.Extensions.DependencyInjection;
using CabinetVeterinarMobile.Views;

namespace CabinetVeterinarMobile
{
    public partial class App : Application
    {
        public App(PetsPage petsPage)
        {
            InitializeComponent();
            MainPage = new NavigationPage(petsPage);
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}