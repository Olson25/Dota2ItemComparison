using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;


namespace WebApplication1.Models
{
    public class BuildModel
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Hero is required")]
        public string Hero { get; set; }
        public int heroID { get; set; }
        [DisplayName("Item Slot 1")]
        //[EnumDataType(typeof(AppEnum.items))]
        public AppEnum.items Item1 { get; set; }
        [DisplayName("Item Slot 2")]
        //[EnumDataType(typeof(AppEnum.items))]
        public AppEnum.items Item2 { get; set; }
        [DisplayName("Item Slot 3")]
        //[EnumDataType(typeof(AppEnum.items))]
        public AppEnum.items Item3 { get; set; }
        [DisplayName("Item Slot 4")]
        // [EnumDataType(typeof(AppEnum.items))]
        public AppEnum.items Item4 { get; set; }
        [DisplayName("Item Slot 5")]
        //[EnumDataType(typeof(AppEnum.items))]
        public AppEnum.items Item5 { get; set; }
        [DisplayName("Item Slot 6")]
        // [EnumDataType(typeof(AppEnum.items))]
        public AppEnum.items Item6 { get; set; }
        [DisplayName("Moonshard eaten?")]
        public bool MoonShardEaten { get; set; }
        [DisplayName("Hero Level")]
        [Required(ErrorMessage = "Level is required")]
        [Range(1, 25, ErrorMessage = "Please choose a valid level (1-25)")]
        public int level { get; set; }

    }
}