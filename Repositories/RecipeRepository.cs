using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasteBitesApi.Data;
using TasteBitesApi.Dtos.Recipes;
using TasteBitesApi.Interfaces;
using TasteBitesApi.Models;

namespace TasteBitesApi.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDBContext _context;
        public RecipeRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<Recipe> CreateNewRecipeAsync(CreateRecipeDto CreateRecipeDto, string UserID)
        {
            Recipe Recipe = new Recipe()
            {
                Name  = CreateRecipeDto.Name,
                PreparationTime = CreateRecipeDto.PreparationTime,
                Servings = CreateRecipeDto.Servings,
                DificultyLevel = CreateRecipeDto.DificultyLevel,
                Description  = CreateRecipeDto.Name,
                Ingredients  = CreateRecipeDto.Name,
                Instructions  = CreateRecipeDto.Name,
                NutrionalValues  = CreateRecipeDto.Name,
                Category  = CreateRecipeDto.Name,
                CreatorID = UserID
            };

            await _context.Recipes.AddAsync(Recipe);
            await _context.SaveChangesAsync();

            return Recipe;
        }

        public async Task<Recipe?> DeleteRecipeAsync(int id, string UserID)
        {
            var recipeToDelete = await _context.Recipes.FirstOrDefaultAsync(x => x.Id == id);

            if (recipeToDelete == null)
                return null;
            
            if(recipeToDelete.CreatorID != UserID)
                throw new Exception("Cant delete this recipe");

            _context.Recipes.Remove(recipeToDelete);
            await _context.SaveChangesAsync();

            return recipeToDelete;
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(x=> x.Id == id); 

            if(recipe == null)
                return null;

            return recipe;
        }

        public async Task<List<Recipe>> GetRecipesAsync()
        {
            List<Recipe> Recipes = await _context.Recipes.ToListAsync();
            return Recipes;
        }

        public async Task<Recipe?> UpdateRecipeAsync(int id, UpdateRecipeDto UpdateRecipeDto,string UserID)
        {
            var recipeToUpdate = await _context.Recipes.FirstOrDefaultAsync(x => x.Id == id);


            if (recipeToUpdate == null)
                return null;

            
            if(recipeToUpdate.CreatorID != UserID)
                throw new Exception("Can't update this recipe");
                
            recipeToUpdate.Name  = UpdateRecipeDto.Name;
            recipeToUpdate.PreparationTime = UpdateRecipeDto.PreparationTime;
            recipeToUpdate.Servings = UpdateRecipeDto.Servings;
            recipeToUpdate.DificultyLevel = UpdateRecipeDto.DificultyLevel;
            recipeToUpdate.Description  = UpdateRecipeDto.Name;
            recipeToUpdate.Ingredients  = UpdateRecipeDto.Name;
            recipeToUpdate.Instructions  = UpdateRecipeDto.Name;
            recipeToUpdate.NutrionalValues  = UpdateRecipeDto.Name;
            recipeToUpdate.Category  = UpdateRecipeDto.Name;

            await _context.SaveChangesAsync();

            return recipeToUpdate;
        }
    }
}