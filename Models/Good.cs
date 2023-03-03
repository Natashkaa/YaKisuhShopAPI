using System;
using System.Collections.Generic;

namespace YaKisuhShopApi.Models
{
    public partial class Good
    {
        public Good()
        {
            GoodImages = new HashSet<GoodImage>();
            Sales = new HashSet<Sale>();
        }

        public int GoodId { get; set; }
        public string GoodName { get; set; } = null!;
        public int GoodPrice { get; set; }
        public int GoodType { get; set; }
        public string GoodDescription { get; set; } = null!;
        public Boolean IsOnSale { get; set; }

        public virtual GoodType GoodTypeNavigation { get; set; } = null!;
        public virtual ICollection<GoodImage> GoodImages { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
