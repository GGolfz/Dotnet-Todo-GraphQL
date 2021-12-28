using HotChocolate;
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
    }
}