using HotChocolate;
using Microsoft.AspNetCore.Mvc;
namespace TodoGraphQL.Models
{
    public class Mutation {
        public async Task<TodoItem> AddTodoItem(long id, string name, string description, [Service] TodoContext context) {
            var item = new TodoItem {
                Id=id,
                Name=name,
                Description=description,
                IsComplete=false
            };
            context.TodoItems.Add(item);
            await context.SaveChangesAsync();
            return item;
        }
        public async Task<TodoItem?> EditTodoItem(long id, string name, string description, bool isComplete, [Service] TodoContext context) {
            var item = await context.TodoItems.FindAsync(id);
            if (item == null) return null;
            item.Name = name;
            item.Description = description;
            item.IsComplete = isComplete;
            await context.SaveChangesAsync();
            return item;
        } 
        public async Task<bool?> DeleteTodoItem(long id, [Service] TodoContext context) {
            var item = await context.TodoItems.FindAsync(id);
            if(item == null) return null;
            context.TodoItems.Remove(item);
            await context.SaveChangesAsync();
            return true;
        }
    }
}