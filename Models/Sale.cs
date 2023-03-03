using System;
using System.Collections.Generic;

namespace YaKisuhShopApi.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerEmail { get; set; } = null!;
        public int GoodId { get; set; }

        public virtual Good Good { get; set; } = null!;
    }
}
