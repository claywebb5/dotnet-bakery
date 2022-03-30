using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    public class Baker 
    {
        public int id {get; set;} // id
        
        [Required] // This is an Attribute
        // Just like NOT NULL
        public string name {get; set;}
    }
}
