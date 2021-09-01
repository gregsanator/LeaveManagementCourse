using AutoMapper;
using LeaveManagementCourse.Models;
using LeaveManagementCourse.VievModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementCourse.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<LeaveTypes, LeaveTypesVM>().ReverseMap();
            CreateMap<LeaveHistories, LeaveHistoriesVM>().ReverseMap();
            CreateMap<LeaveAllocations, LeaveAllocationsVM>().ReverseMap();
            CreateMap<Employees, EmployeesVM>().ReverseMap();
        }
    }
}
