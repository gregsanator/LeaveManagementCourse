﻿using LeaveManagementCourse.Contracts;
using LeaveManagementCourse.Data;
using LeaveManagementCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementCourse.Repository
{
    public class LeaveTypesRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveTypesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveTypes entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveTypes entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveTypes> FindAll() 
        {
           return _db.LeaveTypes.ToList(); // give me back all the LeaveTypes, toList because we are expecting ICollection, some type of collection...
            
        }

        public LeaveTypes FindById(int id)
        {
            return _db.LeaveTypes.Find(id);
        }

        public bool Save()
        {
            var numberOfChanges =_db.SaveChanges(); // save the changes
            return numberOfChanges > 0; // return true if number of changes is greater than 0
        }

        public bool Update(LeaveTypes entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
