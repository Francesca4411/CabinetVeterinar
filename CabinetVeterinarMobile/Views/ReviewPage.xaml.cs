using CabinetVeterinarMobile.Data;
using CabinetVeterinarMobile.Models;

namespace CabinetVeterinarMobile.Views;

public partial class ReviewPage : ContentPage
{
    private readonly VetDatabase _db;
    private readonly Review _review;

    public ReviewPage(VetDatabase db, Review? review = null)
    {
        InitializeComponent();
        _db = db;
        _review = review ?? new Review();

        Title = _review.Id == 0 ? "Add Review" : "Edit Review";

        AppointmentIdEntry.Text = _review.AppointmentId.ToString();
        RatingEntry.Text = _review.Rating.ToString();
        TextEditor.Text = _review.Text;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (!int.TryParse(AppointmentIdEntry.Text, out int apptId) || apptId <= 0)
        {
            await DisplayAlertAsync("Validation", "AppointmentId must be a positive number.", "OK");
            return;
        }

        if (!int.TryParse(RatingEntry.Text, out int rating) || rating < 1 || rating > 5)
        {
            await DisplayAlertAsync("Validation", "Rating must be between 1 and 5.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(TextEditor.Text))
        {
            await DisplayAlertAsync("Validation", "Text is required.", "OK");
            return;
        }

        _review.AppointmentId = apptId;
        _review.Rating = rating;
        _review.Text = TextEditor.Text.Trim();

        await _db.InitAsync();
        await _db.SaveReviewAsync(_review);

        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_review.Id == 0)
        {
            await Navigation.PopAsync();
            return;
        }

        bool ok = await DisplayAlertAsync("Confirm", "Delete this review?", "Yes", "No");
        if (!ok) return;

        await _db.DeleteReviewAsync(_review);
        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}