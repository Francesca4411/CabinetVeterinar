using CabinetVeterinarMobile.Data;
using CabinetVeterinarMobile.Models;

namespace CabinetVeterinarMobile.Views;

public partial class PetsPage : ContentPage
{
    private readonly VetDatabase _db;

    public PetsPage(VetDatabase db)
    {
        InitializeComponent();
        _db = db;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _db.InitAsync();
        PetsCollection.ItemsSource = await _db.GetPetsAsync();
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PetPage(_db));
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection?.FirstOrDefault() is not Pet selected)
            return;

        PetsCollection.SelectedItem = null;

        await Navigation.PushAsync(new PetPage(_db, selected));
    }

    private async void OnAppointmentsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AppointmentsPage(_db));
    }

    private async void OnReviewsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReviewsPage(_db));
    }
}