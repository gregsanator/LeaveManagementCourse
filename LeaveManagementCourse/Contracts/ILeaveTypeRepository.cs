using LeaveManagementCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// in this file we will define all the operations that we will make with the LeaveTypes object

namespace LeaveManagementCourse.Contracts
{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveTypes> // inherit from IRepositoryBase<type of object(in this case LeaveTypes)>
    {

    }
}
