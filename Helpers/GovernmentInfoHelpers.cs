using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Info;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JwtAuthDemo.Helpers
{
    public class GovernmentInfoHelper
    {
        private readonly Appdatacontext _context;
        public GovernmentInfoHelper(Appdatacontext context)
        {
            _context = context;
        }

        public async Task<GovernmentInfo> Save(GovernmentInfo model)
        {
            _context.GovernmentInfo.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<GovernmentInfo>> Get(int employeeId)
        {
            return await _context.GovernmentInfo.Where(a => a.Employee.Id == employeeId).ToListAsync();
        }

        public async Task<GovernmentInfo> Update(GovernmentInfo model, int id)
        {
            var background = await _context.GovernmentInfo.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            background = model;
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            bool isDeleted = false;

            var background = await _context.GovernmentInfo.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            _context.GovernmentInfo.Remove(background);
            await _context.SaveChangesAsync();

            return isDeleted = true;
        }


    }
}
