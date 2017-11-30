using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    [MetadataType(typeof(PersonMetaData))]
    public partial class Person
    {

    }
    
    public class PersonMetaData
    {
        [StringLength(10,MinimumLength =2)]
        public string Name { get; set; }
        public int? Age { get; set; }

    }
}