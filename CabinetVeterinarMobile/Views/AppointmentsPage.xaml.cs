using CabinetVeterinarMobile.Data;
using CabinetVeterinarMobile.Models;
using CabinetVeterinarMobile.Services;

namespace CabinetVeterinarMobile.Views;

public partial class AppointmentsPage : ContentPage
{
    private readonly VetDatabase _db;
    private readonly ApiService _api = new ApiService();

    public AppointmentsPage(VetDatabase db)
    {
        InitializeComponent();
        _db = db;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            var items = await _api.GetAppointmentsAsync();
            AppointmentsCollection.ItemsSource = items;
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("API error", ex.Message, "OK");
        }
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AppointmentPage(_db));
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection?.FirstOrDefault() is not Appointment selected)
            return;

        AppointmentsCollection.SelectedItem = null;
        await Navigation.PushAsync(new AppointmentPage(_db, selected));
    }

    private async void OnBackToPetsClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}