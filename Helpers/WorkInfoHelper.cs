using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Info;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JwtAuthDemo.Helpers
{
    public class WorkInfoHelper
    {
        private readonly Appdatacontext _context;

        public WorkInfoHelper(Appdatacontext context)
        {
            _context = context;
        }


        public async Task<WorkInfo> Save(WorkInfo model)
        {
            _context.WorkInfo.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<WorkInfo>> Get()
        {
            return await _context.WorkInfo.ToListAsync();
        }

        public async Task<IEnumerable<WorkInfo>> Get(int employeeId)
        {
            return await _context.WorkInfo.Where(a => a.Id == employeeId).ToListAsync();
        }

        public async Task<WorkInfo> Update(WorkInfo model, int id)
        {
            var Info = await _context.WorkInfo.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (Info == null)
                throw new Exception($"{id} not found.");

            Info = model;
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            bool isDeleted = false;

            var Info = await _context.WorkInfo.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (Info == null)
                throw new Exception($"{id} not found.");

            _context.WorkInfo.Remove(Info);
            await _context.SaveChangesAsync();

            return isDeleted = true;
        }


    }
}
