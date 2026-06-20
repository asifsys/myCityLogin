using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myCityLogin.HospitalService.API.Data;
using myCityLogin.HospitalService.API.Interfaces;
using myCityLogin.HospitalService.API.Models;
 
namespace myCityLogin.HospitalService.API.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly HospitalDbContext _context;

        public HospitalRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hospital>> GetAll()
        {
            return await _context.Hospitals
                .Where(h => h.IsActive)
                .OrderBy(h => h.Name)
                .ToListAsync();
        }

        public async Task<PagedResult<Hospital>> SearchAll( string? location, string? category, int page = 1, int pageSize = 10)

        {
            var query = _context.Hospitals.AsQueryable();

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(x => x.Location.Contains(location));
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(x => x.Name.Contains(category));
            }

            var totalRecords = await query.CountAsync();

            var result = await query
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Hospital>
            {
                Data = result,
                Total = totalRecords
            };
        }



        public async Task<IEnumerable<Hospital>> Search(string? location, string? category)
        {
            var query = _context.Hospitals.Where(h => h.IsActive);

            if (!string.IsNullOrWhiteSpace(location))
                query = query.Where(h =>
                    h.Location.Contains(location) ||
                    h.Address.Contains(location));

            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(h =>
                    h.Name.Contains(category) ||
                    h.Specialization.Contains(category));

            return await query.OrderBy(h => h.Name).ToListAsync();
        }

        public async Task<Hospital?> GetById(int id)
        {
            return await _context.Hospitals
                .FirstOrDefaultAsync(h => h.Id == id && h.IsActive);
        }

        public async Task<Hospital> Create(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();
            return hospital;
        }

        public async Task<Hospital?> Update(int id, Hospital hospital)
        {
            var existing = await _context.Hospitals.FindAsync(id);

            if (existing == null)
                return null;

            existing.Name = hospital.Name;
            existing.Location = hospital.Location;
            existing.Address = hospital.Address;
            existing.Phone = hospital.Phone;
            existing.Email = hospital.Email;
            existing.Specialization = hospital.Specialization;
            existing.IsActive = hospital.IsActive;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);

            if (hospital == null)
                return false;

            hospital.IsActive = false; // soft delete

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
