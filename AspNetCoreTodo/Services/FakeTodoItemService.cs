using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            var item1 = new TodoItem
            {
                Title = "Learn ASP.NET Core",
                StartDate = DateTime.Now,
                NumberofDays = 20,
                Priority = 5,
                DueAt = DateTimeOffset.Now.AddDays(31)
            };

            var item2 = new TodoItem
            {
                Title = "Build awesome apps",
                StartDate = DateTime.Now,
                NumberofDays = 4,
                Priority = 4,
                DueAt = DateTimeOffset.Now.AddDays(5)
            };

            var item3 = new TodoItem
            {
                Title = "Learn ASP.NET",
                StartDate = DateTime.Now,
                NumberofDays = 3,
                Priority = 3,
                DueAt = DateTimeOffset.Now.AddDays(4)
            };

            var item4 = new TodoItem
            {
                Title = "Build apps",
                StartDate = DateTime.Now,
                NumberofDays = 5,
                Priority = 2,
                DueAt = DateTimeOffset.Now.AddDays(6)
            };

            var item5 = new TodoItem
            {
                Title = "Build apps",
                StartDate = DateTime.Now,
                NumberofDays = 4,
                Priority = 1,
                DueAt = DateTimeOffset.Now.AddDays(4)
            };

            return Task.FromResult(new[] { item1, item2, item3, item4, item5 });
        }

        public Task<bool> AddItemAsync(TodoItem newItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkDoneAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}