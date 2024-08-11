using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasteBitesApi.Dtos.Recipes;
using TasteBitesApi.Models;

namespace TasteBitesApi.Mappers
{
    public static class RecipeMapper
    {
        public static RecipeDto ToRecipeDto(this Recipe recipe)
        {
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                PreparationTime = recipe.PreparationTime,
                Servings = recipe.Servings,
                DificultyLevel = recipe.DificultyLevel,
                Description = recipe.Description,
                Ingredients = recipe.Ingredients.ToList(),
                Instructions = recipe.Instructions.ToList(),
                NutrionalValues = recipe.NutrionalValues,
                Likes = recipe.Likes,
                Rating = recipe.RatingTotalVotes != 0 ? recipe.Rating / recipe.RatingTotalVotes : 0,
                Category = recipe.Category,
                CreationTime = recipe.CreationTime,
                CreatorID = recipe.CreatorID,
                Comments  = new List<Comment>().ToList()
            };
        }
    }
}