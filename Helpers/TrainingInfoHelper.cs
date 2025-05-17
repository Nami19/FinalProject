using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Info;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JwtAuthDemo.Helpers
{
    public class TrainingInfoHelper
    {
        private readonly Appdatacontext _context;

        public TrainingInfoHelper(Appdatacontext context)
        {
            _context = context;
        }


        public async Task<TrainingInfo> Save(TrainingInfo model)
        {
            _context.TrainingInfo.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<TrainingInfo>> Get()
        {
            return await _context.TrainingInfo.ToListAsync();
        }

        public async Task<IEnumerable<TrainingInfo>> Get(int employeeId)
        {
            return await _context.TrainingInfo.Where(a => a.Id == employeeId).ToListAsync();
        }

        public async Task<TrainingInfo> Update(TrainingInfo model, int id)
        {
            var background = await _context.TrainingInfo.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            background = model;
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            bool isDeleted = false;

            var background = await _context.TrainingInfo.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            _context.TrainingInfo.Remove(background);
            await _context.SaveChangesAsync();

            return isDeleted = true;
        }


    }
}
