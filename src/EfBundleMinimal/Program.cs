global using Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddModel(builder.Configuration.GetConnectionString("DefaultConnection"));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapGet("/", () => "Hello World!");
app.MapGet("/products", (ModelContext context) => context.Products);
app.MapGet("/product/{id}", (ModelContext context, int id) => context.Products.Where(s => s.Id == id));
app.MapGet("/sales", (ModelContext context) => context.Sales);
app.MapGet("/sales/{id}", (ModelContext context, int id) => context.Sales.Where(s => s.Id == id));

app.Run();
