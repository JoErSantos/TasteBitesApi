using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TasteBitesApi.Models
{
    [Table("User")]
    public class User : IdentityUser
    {
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}