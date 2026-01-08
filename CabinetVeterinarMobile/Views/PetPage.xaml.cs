using CabinetVeterinarMobile.Data;
using CabinetVeterinarMobile.Models;

namespace CabinetVeterinarMobile.Views;

public partial class PetPage : ContentPage
{
    private readonly VetDatabase _db;
    private readonly Pet _pet;

    public PetPage(VetDatabase db, Pet? pet = null)
    {
        InitializeComponent();
        _db = db;
        _pet = pet ?? new Pet();

        Title = _pet.Id == 0 ? "Add Pet" : "Edit Pet";

        NameEntry.Text = _pet.Name;
        SpeciesEntry.Text = _pet.Species;
        BreedEntry.Text = _pet.Breed;
        AgeEntry.Text = _pet.AgeYears?.ToString() ?? "";
        OwnerEntry.Text = _pet.OwnerName;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlertAsync("Validation", "Name is required.", "OK");
            return;
        }

        _pet.Name = NameEntry.Text.Trim();
        _pet.Species = string.IsNullOrWhiteSpace(SpeciesEntry.Text) ? "Dog" : SpeciesEntry.Text.Trim();
        _pet.Breed = string.IsNullOrWhiteSpace(BreedEntry.Text) ? null : BreedEntry.Text.Trim();
        _pet.OwnerName = string.IsNullOrWhiteSpace(OwnerEntry.Text) ? null : OwnerEntry.Text.Trim();

        if (int.TryParse(AgeEntry.Text, out int age))
            _pet.AgeYears = age;
        else
            _pet.AgeYears = null;

        await _db.InitAsync();
        await _db.SavePetAsync(_pet);

        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_pet.Id == 0)
        {
            await Navigation.PopAsync();
            return;
        }

        bool ok = await DisplayAlertAsync("Confirm", "Delete this pet?", "Yes", "No");
        if (!ok) return;

        await _db.DeletePetAsync(_pet);
        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}