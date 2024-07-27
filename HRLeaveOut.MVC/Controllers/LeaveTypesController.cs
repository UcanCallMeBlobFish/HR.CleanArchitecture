using HRLeaveOut.MVC.Contracts;
using HRLeaveOut.MVC.Models;
using HRLeaveOut.MVC.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveOut.MVC.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;
        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }
        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypes();
            return View(leaveTypes);
        }

        // GET: LeaveTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var detailedLeaveType = await _leaveTypeService.GetLeaveTypeDetails(id); 
            return View(detailedLeaveType);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVM leaveTypeVMobj)
        {
            try
            {
                var response = await _leaveTypeService.CreateLeaveType(leaveTypeVMobj);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));

                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(leaveTypeVMobj);

        }

        // GET: LeaveTypesController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View();
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeVM leaveType)
        {
            try
            {
                var response = await _leaveTypeService.UpdateLeaveType(id, leaveType);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(leaveType);
        }

       
        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _leaveTypeService.DeleteLeaveType(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

    }
}
