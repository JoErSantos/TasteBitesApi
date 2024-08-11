using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TasteBitesApi.Dtos.Recipes;
using TasteBitesApi.Interfaces;
using TasteBitesApi.Mappers;
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
            List<Recipe> recipes = await _recipeRepository.GetRecipesAsync();
            return Ok(recipes.Select(x => x.ToRecipeDto()).ToList());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateNewRecipe([FromBody]CreateRecipeDto recipeDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUserName();
            var user = await _userManager.FindByNameAsync(username);
            
            Recipe newRecipe = await _recipeRepository.CreateNewRecipeAsync(recipeDto,user.Id);

            if (newRecipe == null)
                return StatusCode(500,"Creation of new recipe wasn't possible");

            return Ok(newRecipe.ToRecipeDto());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRecipeById([FromRoute]int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            if(recipe == null)
                return NotFound("Recipe not found");

            return Ok(recipe.ToRecipeDto());
        }

        [HttpPut]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateRecipe([FromRoute] int id, [FromBody] UpdateRecipeDto recipeDto)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var username = User.GetUserName();
                var user = await _userManager.FindByNameAsync(username);

                var recipeUpdated = await _recipeRepository.UpdateRecipeAsync(id, recipeDto, user.Id);

                if(recipeUpdated == null)
                    return NotFound("The recipe you want to update does not exist");

                return Ok(recipeUpdated.ToRecipeDto());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteRecipe([FromRoute]int id)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var username = User.GetUserName();
                var user = await _userManager.FindByNameAsync(username);

                var recipeDeleted = await _recipeRepository.DeleteRecipeAsync(id,user.Id);

                if(recipeDeleted == null)
                    return NotFound("The recipe you wanto to delete does not exist");

                return NoContent();
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }
    }
}