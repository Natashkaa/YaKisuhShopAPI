using System;
using System.Collections.Generic;

namespace YaKisuhShopApi.Models
{
    public partial class GoodImage
    {
        public int ImageId { get; set; }
        public string ImageLink { get; set; } = null!;
        public int GoodId { get; set; }

        public virtual Good Good { get; set; } = null!;
    }
}
