using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class HeroModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Hero name is required")]
        [DisplayName("Hero")]
        public string heroName { get; set; }
        [Required(ErrorMessage = "Primary Attribute is required")]
        // [EnumDataType(typeof(AppEnum.attribute))]
        [DisplayName("Primary Attribute")]
        public AppEnum.attribute primaryAttribute { get; set; }
        [Required(ErrorMessage = "Must specify whether or not the hero is ranged")]
        public bool ranged { get; set; }

        public double BAT { get; set; }
        [Required(ErrorMessage = "Base Agility is required")]
        [DisplayName("Base Agility")]
        public double baseAgi { get; set; }
        [Required(ErrorMessage = "Base Strength is required")]
        [DisplayName("Base Strength")]
        public double baseStr { get; set; }
        [DisplayName("Base Intelligence")]
        [Required(ErrorMessage = "Base intelligence is required")]
        public double baseInt { get; set; }
        [Required(ErrorMessage = "Agility gain is required")]
        [DisplayName("Agility Gain")]
        public double AgiGain { get; set; }
        [DisplayName("Strength Gain")]
        [Required(ErrorMessage = "Strength gain is required")]
        public double StrGain { get; set; }
        [DisplayName("Intelligence Gain")]
        [Required(ErrorMessage = "Intelligence gain is required")]
        public double IntGain { get; set; }
        [Required(ErrorMessage = "Base speed is required")]
        [Range(1, 522, ErrorMessage = "Please choose a valid move speed")]
        [DisplayName("Base Speed")]
        public double baseSpeed { get; set; }
        [Required(ErrorMessage = "Base damage is required")]
        [DisplayName("Base Damage")]
        public double baseDamage { get; set; }
        [DisplayName("Base Armor")]
        [Required(ErrorMessage = "Base armor is required")]
        public double baseArmor { get; set; }
        public ICollection<BuildModel> Builds { get; set; }
    }
}