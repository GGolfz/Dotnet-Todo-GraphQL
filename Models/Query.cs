namespace TodoGraphQL.Models
{
    public class Query
    {
        public IQueryable<TodoItem> Todos => new List<TodoItem>{
            new TodoItem{
                Id = 1,
                Name = "test",
                Description = "test desc",
                IsComplete = true
            },
            new TodoItem {
                Id = 2,
                Name = "test2",
                Description = "test2 desc",
                IsComplete = false
            }
        }.AsQueryable();
    }
}