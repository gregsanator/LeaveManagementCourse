using AutoMapper;
using LeaveManagementCourse.Contracts;
using LeaveManagementCourse.Data;
using LeaveManagementCourse.Models;
using LeaveManagementCourse.VievModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementCourse.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveTypesController : Controller
    {
        private ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: LeaveTypesController
        public ActionResult Index()
        {
            var leaveTypes = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LeaveTypesVM>>(leaveTypes);
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            else
            {
                LeaveTypesVM leaveTypesVM = new LeaveTypesVM();
                LeaveTypes leaveTypes = _repo.FindById(id);
                leaveTypesVM.Id = leaveTypes.Id;
                leaveTypesVM.Name = leaveTypes.Name;
                leaveTypesVM.DateCreated = leaveTypes.DateCreated;
                return View(leaveTypesVM);
            }
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypesVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model); // return the edit View and pass the same object
                }
                LeaveTypes leaveTypes = new LeaveTypes();
                leaveTypes.Name = model.Name;
                leaveTypes.DateCreated = DateTime.Now;
                bool isSuccess = _repo.Create(leaveTypes);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Sorry but something went wrong! Please try again!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Sorry but something went wrong! Please try again!");
                return View(model);
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            LeaveTypes leaveTypes = _repo.FindById(id);
            LeaveTypesVM leaveTypesVM = new LeaveTypesVM();
            leaveTypesVM.Id = leaveTypes.Id;
            leaveTypesVM.Name = leaveTypes.Name;
            leaveTypesVM.DateCreated = leaveTypes.DateCreated;
            return View(leaveTypesVM);
            //var model = _mapper.Map<LeaveTypesVM>(leaveTypes);
            //return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypesVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model); // return the edit View and pass the same object
                }
                LeaveTypes leaveTypes = new LeaveTypes();
                leaveTypes.Id = model.Id;
                leaveTypes.Name = model.Name;
                leaveTypes.DateCreated = (DateTime)model.DateCreated;
                var isSuccess = _repo.Update(leaveTypes);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Sorry but something went wrong! Please try again!");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Sorry but something went wrong! Please try again!");
               return View(model);
            }
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            var leaveTypes = _repo.FindById(id);
            if (leaveTypes == null)
            {
                return NotFound();
            }
            var isDeleted = _repo.Delete(leaveTypes);
            if (!isDeleted)
            {
                ModelState.AddModelError("", "Sorry but something went wrong! Please try again!");
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, LeaveTypesVM model)
        {
            try
            {
                var leaveTypes = _repo.FindById(id);
                if(leaveTypes == null)
                {
                    return NotFound();
                }
                var isDeleted = _repo.Delete(leaveTypes);
                if (!isDeleted)
                {
                    ModelState.AddModelError("", "Sorry but something went wrong! Please try again!");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Sorry but something went wrong! Please try again!");
                return View(model);
            }
        }
    }
}
