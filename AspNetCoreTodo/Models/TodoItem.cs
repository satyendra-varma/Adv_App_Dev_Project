using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTodo.Models
{
    public class TodoItem : IComparable<TodoItem>
    {
        public Guid Id { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public string Title { get; set; } = " "; // given default value to get rid of the non-nullable warning

        public DateTimeOffset StartDate { get; set; }
   
        public int NumberofDays { get; set; }

        public int Priority { get; set; }

        [Required]
        public DateTimeOffset DueAt { get; set; }

        public string UserId { get; set; } = "";

        public int CompareTo(TodoItem? other)    
        {    
            if (other == null) return 1;    
            TodoItem nextitem = other as TodoItem;    
            if(nextitem != null)    
            {
                if (this.Priority > nextitem.Priority)
                    return 1;
                else if (this.Priority == nextitem.Priority)
                    return 0;
                else
                    return -1;  
            }    
            else    
            {    
                throw new ArgumentException("Provided incorrect items");    
            }    
        }
    }
}