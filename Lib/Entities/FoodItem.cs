using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Lib.Entities
{
    public partial class FoodItem
    {
        public long Id { get; set; }
        public string ImgSource { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}
