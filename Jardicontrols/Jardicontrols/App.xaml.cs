using Plugin.BLE.Abstractions.Contracts;
using Xamarin.Forms;

namespace Jardicontrols
{
    public partial class App : Application
    {
        public static IDevice device { get; set; }
        public App()
        {
            device = null;
            InitializeComponent();

            MainPage = new JardicontrolsPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
