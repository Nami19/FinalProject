using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Info;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthDemo.Helpers
{
    public class EducationalInformationHelper
    {
        private readonly Appdatacontext _context;
        public EducationalInformationHelper(Appdatacontext context)
        {
            _context = context;
        }

        public async Task<Educationalbackground> Save(Educationalbackground model)
        {
            _context.Educationalbackground.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<Educationalbackground>> Get(int employeeId)
        {
            return await _context.Educationalbackground.Where(a => a.Employee.Id == employeeId).ToListAsync();
        }

        public async Task<Educationalbackground> Update(Educationalbackground model, int id)
        {
            var background = await _context.Educationalbackground.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            background = model;
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            bool isDeleted = false;

            var background = await _context.Educationalbackground.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            _context.Educationalbackground.Remove(background);
            await _context.SaveChangesAsync();

            return isDeleted = true;
        }

       
    }
}
