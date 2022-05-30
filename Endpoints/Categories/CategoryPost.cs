
using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories
{
    public class CategoryPost
    {
        public static string Template => "/categories";
        public static string[] Methods { get; set; } = new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action (CategoryRequest categoryRequest, ApplicationDbContext context)
        {
            var category = new Category
            {
                Name = categoryRequest.Name,
                CreatedBy = "Test",
                CreatedOn = DateTime.Now,
                EditedBy = "Test",
                EditedOn = DateTime.Now,
            };
            context.Add(category);
            context.SaveChanges();

            return Results.Created($"/categories/{category.Id}", category.Id);
        }
    }
}
