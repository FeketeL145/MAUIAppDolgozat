using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.Generic;

namespace MAUIAppDolgozat20240130
{
    public partial class MainPage : ContentPage
    {
        static string udvfelhasznalo;
        public static string Udvfelhasznalo { get => udvfelhasznalo; set => udvfelhasznalo = value; }
        public class Felhasznalo
        {
            public string felhasznalonev;
            public string jelszo;
            public Felhasznalo(string felhasznalonev, string jelszo)
            {
                this.felhasznalonev = felhasznalonev;
                this.jelszo = jelszo;
            }
        }
        List<Felhasznalo> felhasznaloList = new List<Felhasznalo>();
        public MainPage()
        {
            InitializeComponent();
        }
        
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            Felhasznalo felhbejelentkezes = new Felhasznalo(EtrFelhNev.Text, EtrJelszo.Text);
            if (felhasznaloList.Any(felhasznalo => felhasznalo.felhasznalonev == felhbejelentkezes.felhasznalonev))
            {
                Felhasznalo letezoFelhasznalo = felhasznaloList.First(felhasznalo => felhasznalo.felhasznalonev == felhbejelentkezes.felhasznalonev);
                if (felhbejelentkezes.jelszo == letezoFelhasznalo.jelszo)
                {
                    udvfelhasznalo = felhbejelentkezes.felhasznalonev;
                    await Shell.Current.GoToAsync("LIPage");
                }
                else
                {
                    await DisplayAlert("Hiba!", "Hibás jelszó!", "OK");
                }
            }
            else
            {
                await DisplayAlert("Hiba!", "Nem létezik ilyen felhasználó!", "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            Felhasznalo felhregisztracio = new Felhasznalo(EtrFelhNev.Text, EtrJelszo.Text);
            if (!felhasznaloList.Any(felhasznalo => felhasznalo.felhasznalonev == felhregisztracio.felhasznalonev))
            {
                felhasznaloList.Add(new Felhasznalo(EtrFelhNev.Text, EtrJelszo.Text));
                await DisplayAlert("Sikeres regisztráció!", "Mostmár bejelentkezhet felhasználói fiókjába!", "OK");
            }
            else
            {
                await DisplayAlert("Hiba!", "Már létezik ilyen felhasználó!", "OK");
            }
        }
    }

}
