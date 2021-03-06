using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories
{
    public class CategoryPut
    {
        public static string Template => "/categories{id}";
        public static string[] Methods { get; set; } = new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action ([FromRoute]Guid id, CategoryRequest categoryRequest, ApplicationDbContext context)
        {
            var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();
            category.Name = categoryRequest.Name;
            category.Active = categoryRequest.Active;

            context.SaveChanges();

            return Results.Created($"/categories/{category.Id}", category.Id);
        }
    }
}
