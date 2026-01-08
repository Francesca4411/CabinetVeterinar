using CabinetVeterinarMobile.Data;
using CabinetVeterinarMobile.Models;

namespace CabinetVeterinarMobile.Views;

public partial class AppointmentPage : ContentPage
{
    private readonly VetDatabase _db;
    private readonly Appointment _appt;

    public AppointmentPage(VetDatabase db, Appointment? appt = null)
    {
        InitializeComponent();
        _db = db;
        _appt = appt ?? new Appointment();

        Title = _appt.Id == 0 ? "Add Appointment" : "Edit Appointment";

        var dt = _appt.StartAt == default ? DateTime.Now.AddDays(1) : _appt.StartAt;
        DatePicker.Date = dt.Date;
        TimePicker.Time = dt.TimeOfDay;

        PetIdEntry.Text = _appt.PetId.ToString();
        VetEntry.Text = _appt.VetName;
        ServiceEntry.Text = _appt.ServiceName;
        NotesEditor.Text = _appt.Notes;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (!int.TryParse(PetIdEntry.Text, out int petId) || petId <= 0)
        {
            await DisplayAlertAsync("Validation", "PetId must be a positive number (e.g., 1).", "OK");
            return;
        }

        _appt.PetId = petId;
        _appt.VetName = string.IsNullOrWhiteSpace(VetEntry.Text) ? null : VetEntry.Text.Trim();
        _appt.ServiceName = string.IsNullOrWhiteSpace(ServiceEntry.Text) ? null : ServiceEntry.Text.Trim();
        _appt.Notes = string.IsNullOrWhiteSpace(NotesEditor.Text) ? null : NotesEditor.Text.Trim();

        var date = DatePicker.Date ?? DateTime.Today;
        var time = TimePicker.Time ?? TimeSpan.Zero;

        _appt.StartAt = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds);

        await _db.InitAsync();
        await _db.SaveAppointmentAsync(_appt);

        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_appt.Id == 0)
        {
            await Navigation.PopAsync();
            return;
        }

        bool ok = await DisplayAlertAsync("Confirm", "Delete this appointment?", "Yes", "No");
        if (!ok) return;

        await _db.DeleteAppointmentAsync(_appt);
        await Navigation.PopAsync();
    }

    private async void OnBackToHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}