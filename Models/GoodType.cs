using System;
using System.Collections.Generic;

namespace YaKisuhShopApi.Models
{
    public partial class GoodType
    {
        public GoodType()
        {
            Goods = new HashSet<Good>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<Good> Goods { get; set; }
    }
}
