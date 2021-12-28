using Microsoft.EntityFrameworkCore;
using TodoGraphQL.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.UseEndpoints(endpoints => {
    endpoints.MapGraphQL();
});
app.Run();