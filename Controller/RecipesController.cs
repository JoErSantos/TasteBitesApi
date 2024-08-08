using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TasteBitesApi.Dtos.Recipes;
using TasteBitesApi.Interfaces;
using TasteBitesApi.Models;

namespace TasteBitesApi.Controller
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly UserManager<User> _userManager;

        public RecipesController(UserManager<User> userManager,IRecipeRepository recipeRepository)
        {
            _userManager = userManager;
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getRecipies()
        {
            List<Recipe> recipes = await _recipeRepository.getRecipesAsync();
            return Ok(recipes);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateNewRecipe([FromBody]CreateRecipeDto recipeDto)
        {
            var username = User.GetUserName();
            var user = await _userManager.FindByNameAsync(username);
            if(user == null)
            {
                return StatusCode(500,"What?");
            }
            
            Recipe newRecipe = await _recipeRepository.createNewRecipeAsync(recipeDto,user.Id);

            if (newRecipe == null)
                return StatusCode(500,"Creation of new recipe wasn't possible");

            return Ok(newRecipe);
        }



    }
}