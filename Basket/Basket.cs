using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket
{
    public class Basket : List<Product>
    {
        public decimal Total { get; set; }

        public Basket() { }

        public void TotalPrice()
        {
            Total = this.Sum(x => x.Price);
        }
    }
}
