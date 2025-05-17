using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Info;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JwtAuthDemo.Helpers
{
    public class CertificationAndLicensesHelper
    {
        private readonly Appdatacontext _context;

        public CertificationAndLicensesHelper(Appdatacontext context)
        {
            _context = context;
        }
   
    
        public async Task<CertificationsLicensces> Save(CertificationsLicensces model)
        {
            _context.CertificationsLicenses.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<CertificationsLicensces>> Get()
        {
            return await _context.CertificationsLicenses.ToListAsync();
        }

        public async Task<IEnumerable<CertificationsLicensces>> Get(int employeeId)
        {
            return await _context.CertificationsLicenses.Where(a => a.Id == employeeId).ToListAsync();
        }

        public async Task<CertificationsLicensces> Update(CertificationsLicensces model, int id)
        {
            var background = await _context.CertificationsLicenses.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            background = model;
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            bool isDeleted = false;

            var background = await _context.CertificationsLicenses.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            _context.CertificationsLicenses.Remove(background);
            await _context.SaveChangesAsync();

            return isDeleted = true;
        }


    }
}
