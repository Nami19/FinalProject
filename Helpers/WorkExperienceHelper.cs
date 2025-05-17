using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Info;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthDemo.Helpers
{
    public class WorkExperienceHelper
    {
        private readonly Appdatacontext _context;
        public WorkExperienceHelper(Appdatacontext context)
        {
            _context = context;
        }

        public async Task<WorkExperience> Save(WorkExperience model)
        {
            _context.WorkExperience.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<WorkExperience>> Get(int employeeId)
        {
            return await _context.WorkExperience.Where(a => a.Employee.Id == employeeId).ToListAsync();
        }

        public async Task<WorkExperience> Update(WorkExperience model, int id)
        {
            var background = await _context.WorkExperience.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            background = model;
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            bool isDeleted = false;

            var background = await _context.WorkExperience.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            _context.WorkExperience.Remove(background);
            await _context.SaveChangesAsync();

            return isDeleted = true;
        }


    }
}
