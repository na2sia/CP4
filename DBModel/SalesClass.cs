using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public partial class Sales
    {
        public Sales() { }
        public Sales (DateTime date, int managerid, int clientid, int goodsid, double cost)
        {
            this.Date = date;
            this.ManagerId = managerid;
            this.ClientId = clientid;
            this.GoodsId = goodsid;
            this.Cost = cost;
        }

    }
}
