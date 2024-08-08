using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasteBitesApi.Dtos.Recipes;
using TasteBitesApi.Models;

namespace TasteBitesApi.Interfaces
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> getRecipesAsync ();
        Task<Recipe> createNewRecipeAsync(CreateRecipeDto createRecipeDto, string UserId);
    }
}