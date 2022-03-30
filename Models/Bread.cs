using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    // To set the specific types of bread we will 
    // use an Enum type (which is essentially a list)
    public enum BreadType
    {
        Sourdough, // Index number is: 0
        Pumpernickel, // Index number is: 1
        French, // Index number is: 2
        Brioche, // Index number is: 3
        Artisan, // Index number is: 4
        Wheat // Index number is: 5
    }
    public class Bread
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        // Bread type from the above Enum
        // We need this `JsonConverter` attribute
        // to convert our `type` string into an Enum
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BreadType type { get; set; }

        public int count { get; set; }

        // This is the Id of the baker who made this bread
        // In a moment, we'll see how .NET can use this field to 
        // join our tables together for us
        // Relate this bread to the baker in the database
        [ForeignKey("bakedBy")]
        public int bakedById { get; set; }

        // While bakedById is an integer with the baker's ID,
        // this field is an actual Baker object. 
        // This will allow us to nest the baker object
        // inside our bread response from `GET /breads`
        public Baker bakedBy { get; set; }
    }
}
