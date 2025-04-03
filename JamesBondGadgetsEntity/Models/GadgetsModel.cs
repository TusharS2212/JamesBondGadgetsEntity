using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JamesBondGadgetsEntity.Models
{
    public class GadgetsModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        [DisplayName("Appears in this movie")]
        public string AppearsIn { get; set; }
        [Required]
        public string WithThisActor { get; set; }
        public GadgetsModel()
        {
            Id = -1;
            Name = "";
            Description = "";
            AppearsIn = "";
            WithThisActor = "";

        }

        public GadgetsModel(int id, string name, string description, string appearsIn, string withThisActor)
        {
            Id = id;
            Name = name;
            Description = description;
            AppearsIn = appearsIn;
            WithThisActor = withThisActor;
        }
    }
}