using HotChocolate;
namespace TodoGraphQL.Models
{
    public class Query
    {
           public IQueryable<TodoItem> GetTodoItems([Service] TodoContext context) => context.TodoItems;
        public async Task<TodoItem?> GetTodoItemById(long id,[Service] TodoContext context) => await context.TodoItems.FindAsync(id);

    }
}