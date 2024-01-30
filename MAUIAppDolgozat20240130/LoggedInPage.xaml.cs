using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.ObjectModel;

namespace MAUIAppDolgozat20240130.Resources;

public partial class LoggedInPage : ContentPage
{
	public LoggedInPage()
	{
		InitializeComponent();
		UdvFelhLabel.Text = $"Üdvözöljük, {MainPage.Udvfelhasznalo}!";
	}
    async void SaveList()
    {
        try
        {
            var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);

            File.WriteAllLines($"{docsDirectory.AbsoluteFile.Path}/lista.txt", list);
        }
        catch (Exception ex)
        {
            DisplayAlert("Title", ex.Message, "Cancel");
        }
    }
    async void LoadList()
    {
        var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);

        string[] data = File.ReadAllLines($"{docsDirectory.AbsoluteFile.Path}/lista.txt");
        for (int i = 0; i < data.Length; i++)
        {
            list.Add(data[i]);
        }
    }
    ObservableCollection<string> list = new ObservableCollection<string>();
    private async void OnFelvitelClicked(object sender, EventArgs e)
	{
        if (!list.Contains(EtrAdatBe.Text))
        {
            list.Add(EtrAdatBe.Text);
            AdatLista.ItemsSource = list;
        }
        else
        {
            await DisplayAlert("Hiba!", "Már található hasonló adat a listában!", "OK");
        }
    }
    private async void OnBeszurClicked(object sender, EventArgs e)
    {
        if (!list.Contains(EtrAdatBe.Text))
        {
            string kivalElem = AdatLista.SelectedItem.ToString();
            int index = list.IndexOf(kivalElem);
            list.Insert(index, EtrAdatBe.Text);
            AdatLista.ItemsSource = list;
        }
        else
        {
            await DisplayAlert("Hiba!", "Már található hasonló adat a listában!", "OK");
        }
    }
    private async void OnTorlesClicked(object sender, EventArgs e)
    {
        string torolhetoitem = AdatLista.SelectedItem.ToString();
        list.Remove(torolhetoitem);
        AdatLista.ItemsSource = list;
    }
    private async void OnTeljTorlesClicked(object sender, EventArgs e)
    {
        list.Clear();
        AdatLista.ItemsSource = list;
    }
    private async void OnMentClicked(object sender, EventArgs e)
    {
        SaveList();
    }
    private async void OnBetoltClicked(object sender, EventArgs e)
    {
        LoadList();
    }
}