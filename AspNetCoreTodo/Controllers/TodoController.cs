using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            if (TempData["CustomError"] != null)
            {
                ModelState.AddModelError("Validation_Error", TempData["CustomError"].ToString());
                TempData["CustomError"] = null;
            }
            // Get to-do items from database
            var items = await _todoItemService.GetIncompleteItemsAsync();

            // Put items into a model
            var model = new TodoViewModel()
            {
                Items = items
            };

            // Render view using the model
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (newItem.StartDate > newItem.DueAt)
            {
                //ModelState.AddModelError("Date_gap_error", "Due Date must be greater than Start Date.");
                //return BadRequest("Due Date must be greater than Start Date.");
                TempData["CustomError"] = "Due Date must be greater than Start Date.";
                return RedirectToAction("Index");
            }
            else if (int.Parse((newItem.DueAt.DateTime - newItem.StartDate.DateTime).TotalDays.ToString()) < newItem.NumberofDays)
            {
                //ModelState.AddModelError("Duration_error", "Number of days is less than difference between Due Date and Start Date.");
                //return BadRequest("Number of days is less than difference between Due Date and Start Date.");
                TempData["CustomError"] = "Number of days is less than difference between Due Date and Start Date.";
                return RedirectToAction("Index");
            }
            
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTitle(Guid id, string title) {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            var successful = await _todoItemService.UpdateTitleAsync(id, title);
            if (!successful)
            {
                return BadRequest("Could not update Title.");
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStartDate(Guid id, DateTimeOffset startdate)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            var successful = await _todoItemService.UpdateStartDateAsync(id, startdate);
            if (!successful)
            {
                return BadRequest("Could not update start date.");
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateNumberOfDays(Guid id, int numberofdays)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            var successful = await _todoItemService.UpdateNumberOfDaysAsync(id, numberofdays);
            if (!successful)
            {
                return BadRequest("Could not update number of days.");
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePriority(Guid id, int priority)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            var successful = await _todoItemService.UpdatePriorityAsync(id, priority);
            if (!successful)
            {
                return BadRequest("Could not update Priority.");
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDueDate(Guid id, DateTimeOffset duedate)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            var successful = await _todoItemService.UpdateDueDateAsync(id, duedate);
            if (!successful)
            {
                return BadRequest("Could not update due date.");
            }
            return RedirectToAction("Index");
        }
    }
}