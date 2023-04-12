using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync(string user_id);

        Task<bool> AddItemAsync(TodoItem newItem);

        Task<bool> MarkDoneAsync(Guid id);

        Task<bool> UpdateTitleAsync(Guid id, string title);

        Task<bool> UpdateStartDateAsync(Guid id, DateTimeOffset startdate);

        Task<bool> UpdateNumberOfDaysAsync(Guid id, int numberofdays);

        Task<bool> UpdatePriorityAsync(Guid id, int priority);

        Task<bool> UpdateDueDateAsync(Guid id, DateTimeOffset duedate);
    }
}