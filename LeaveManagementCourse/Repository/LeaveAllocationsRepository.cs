using LeaveManagementCourse.Contracts;
using LeaveManagementCourse.Data;
using LeaveManagementCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementCourse.Repository
{
    public class LeaveAllocationsRepository : ILeaveAllocationsRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveAllocationsRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveAllocations entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }
        public bool isExist(int id)
        {
            var exists = _db.LeaveTypes.Any(q => q.Id == id);
            return exists;
        }
        public bool Delete(LeaveAllocations entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocations> FindAll()
        {
            return _db.LeaveAllocations.ToList();
        }

        public LeaveAllocations FindById(int id)
        {
            return _db.LeaveAllocations.Find(id);
            
        }

        public bool Save()
        {
            var numberOfChanges = _db.SaveChanges();
            return numberOfChanges > 0;
        }

        public bool Update(LeaveAllocations entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
