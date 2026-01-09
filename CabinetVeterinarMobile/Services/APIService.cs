using CabinetVeterinarMobile.Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace CabinetVeterinarMobile.Services;

public class ApiService
{
    private readonly HttpClient _http;

    // Alege URL-ul în funcție de platformă:
    // - Windows: https://localhost:7297
    // - Android Emulator: https://10.0.2.2:7297  (localhost-ul PC-ului)
    private const string BaseUrl_Windows = "https://localhost:7297/";
    private const string BaseUrl_Android = "https://10.0.2.2:7297/";

    public ApiService()
    {
        _http = new HttpClient();
    }

    private static string GetBaseUrl()
    {
#if ANDROID
        return BaseUrl_Android;
#else
        return BaseUrl_Windows;
#endif
    }

    public async Task<List<Pet>> GetPetsAsync()
    {
        var url = GetBaseUrl() + "api/petsapi";
        return await _http.GetFromJsonAsync<List<Pet>>(url) ?? new List<Pet>();
    }

    public async Task<List<Appointment>> GetAppointmentsAsync()
    {
        var url = GetBaseUrl() + "api/appointmentsapi";
        return await _http.GetFromJsonAsync<List<Appointment>>(url) ?? new List<Appointment>();
    }

    public async Task<List<Review>> GetReviewsAsync()
    {
        var url = GetBaseUrl() + "api/reviewsapi";
        return await _http.GetFromJsonAsync<List<Review>>(url) ?? new List<Review>();
    }
}

