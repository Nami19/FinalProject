using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Entities;
using JwtAuthDemo.Models.Info;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthDemo.Helpers
{
    public class EmployeeHelper
    {
        private readonly Appdatacontext _context;
        public EmployeeHelper(Appdatacontext context)
        {
            _context = context;
        }

        public async Task<Employee> Save(Employee model)
        {
            _context.Employee.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Get(int employeeId)
        {
            return await _context.Employee.Where(a => a.Id == employeeId).ToListAsync();
        }

        public async Task<Employee> Update(Employee model, int id)
        {
            var background = await _context.Employee.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            background = model;
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            bool isDeleted = false;

            var background = await _context.Employee.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (background == null)
                throw new Exception($"{id} not found.");

            _context.Employee.Remove(background);
            await _context.SaveChangesAsync();

            return isDeleted = true;
        }

       
    }
}
