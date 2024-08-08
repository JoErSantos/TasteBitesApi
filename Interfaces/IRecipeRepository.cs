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
        Task<List<Recipe>> GetRecipesAsync ();
        Task<Recipe> CreateNewRecipeAsync(CreateRecipeDto createRecipeDto, string UserId);
        Task<Recipe?> UpdateRecipeAsync(int id,UpdateRecipeDto updateRecipeDto,string UserId);  
        Task<Recipe?> GetRecipeByIdAsync(int id);
        Task<Recipe?> DeleteRecipeAsync(int id,string UserId);
    }
}