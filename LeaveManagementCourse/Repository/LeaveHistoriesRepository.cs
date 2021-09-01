using LeaveManagementCourse.Contracts;
using LeaveManagementCourse.Data;
using LeaveManagementCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementCourse.Repository
{
    public class LeaveHistoriesRepository : ILeaveHistoriesRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveHistoriesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveHistories entity)
        {
            _db.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistories entity)
        {
            _db.LeaveHistories.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistories> FindAll()
        {
            return _db.LeaveHistories.ToList();
            
        }

        public LeaveHistories FindById(int id)
        {
            return _db.LeaveHistories.Find(id);
        }

        public bool isExist(int id)
        {
            var exists = _db.LeaveTypes.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var numberOfChanges = _db.SaveChanges();
            return numberOfChanges > 0;
        }

        public bool Update(LeaveHistories entity)
        {
            _db.LeaveHistories.Update(entity);
            return Save();
        }
    }
}
