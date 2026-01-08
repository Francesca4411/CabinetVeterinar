using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using CabinetVeterinarMobile.Models;

namespace CabinetVeterinarMobile.Data
{
    public class VetDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public VetDatabase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitAsync()
        {
            await _db.CreateTableAsync<Pet>();
            await _db.CreateTableAsync<Appointment>();
            await _db.CreateTableAsync<Review>();
        }

        // PET
        public Task<List<Pet>> GetPetsAsync() => _db.Table<Pet>().OrderBy(p => p.Name).ToListAsync();
        public Task<Pet> GetPetAsync(int id) => _db.Table<Pet>().Where(p => p.Id == id).FirstOrDefaultAsync();
        public Task<int> SavePetAsync(Pet pet) => pet.Id == 0 ? _db.InsertAsync(pet) : _db.UpdateAsync(pet);
        public Task<int> DeletePetAsync(Pet pet) => _db.DeleteAsync(pet);

        // APPOINTMENT
        public Task<List<Appointment>> GetAppointmentsAsync() => _db.Table<Appointment>().OrderBy(a => a.StartAt).ToListAsync();
        public Task<Appointment> GetAppointmentAsync(int id) => _db.Table<Appointment>().Where(a => a.Id == id).FirstOrDefaultAsync();
        public Task<int> SaveAppointmentAsync(Appointment appt) => appt.Id == 0 ? _db.InsertAsync(appt) : _db.UpdateAsync(appt);
        public Task<int> DeleteAppointmentAsync(Appointment appt) => _db.DeleteAsync(appt);

        // REVIEW
        public Task<List<Review>> GetReviewsAsync() => _db.Table<Review>().OrderByDescending(r => r.Id).ToListAsync();
        public Task<Review> GetReviewAsync(int id) => _db.Table<Review>().Where(r => r.Id == id).FirstOrDefaultAsync();
        public Task<int> SaveReviewAsync(Review r) => r.Id == 0 ? _db.InsertAsync(r) : _db.UpdateAsync(r);
        public Task<int> DeleteReviewAsync(Review r) => _db.DeleteAsync(r);
    }
}
