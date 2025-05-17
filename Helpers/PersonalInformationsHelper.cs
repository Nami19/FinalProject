using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Info;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthDemo.Helpers
{
    public class PersonalInformationsHelper
    {
        private readonly Appdatacontext _context;
        public PersonalInformationsHelper(Appdatacontext context)
        {
            _context = context;
        }

        public async Task<PersonalInformation> Save(PersonalInformation model)
        {
            _context.PersonalInformation.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<PersonalInformation>> Get()
        {
            return await _context.PersonalInformation.ToListAsync();
        }

        public async Task<IEnumerable<PersonalInformation>> Get(int employeeId)
        {
            return await _context.PersonalInformation.Where(a => a.Id == employeeId).ToListAsync();
        }

        public async Task<PersonalInformation> Update(PersonalInformation model, int id)
        {
            var background = await _context.PersonalInformation.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            background = model;
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            bool isDeleted = false;

            var background = await _context.PersonalInformation.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            _context.PersonalInformation.Remove(background);
            await _context.SaveChangesAsync();

            return isDeleted = true;
        }

       
    }
}
