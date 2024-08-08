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

        public async Task<Recipe> createNewRecipeAsync(CreateRecipeDto CreateRecipeDto, string UserID)
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

        public async Task<List<Recipe>> getRecipesAsync()
        {
            List<Recipe> Recipes = await _context.Recipes.ToListAsync();
            return Recipes;
        }
    }
}