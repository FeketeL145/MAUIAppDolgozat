using MAUIAppDolgozat20240130.Resources;

namespace MAUIAppDolgozat20240130
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("LIPage", typeof(LoggedInPage));
            Routing.RegisterRoute("HomePage", typeof(MainPage));
        }
    }
}
