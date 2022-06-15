﻿using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories
{
    public class CategoryGetAll
    {
        public static string Template => "/categories";
        public static string[] Methods { get; set; } = new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action (ApplicationDbContext context)
        {
            var categories = context.Categories.ToList();
            var response = categories.Select(c => new CategoryResponse {Id = c.Id, Name = c.Name, Active = c.Active });

            return Results.Ok(categories);
        }
    }
}
