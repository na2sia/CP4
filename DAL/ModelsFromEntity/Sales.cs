using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelsFromEntity
{
    public class Sales
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public double Cost { get; set; }
        public int ClientId { get; set; }
        public int ManagerId { get; set; }
        public int GoodsId { get; set; }
        
        //public Sales() { }

        //public Sales(DateTime date, int managerid, int clientid, int goodsid, double cost)
        //{
        //    this.Date = date;
        //    this.ManagerId = managerid;
        //    this.ClientId = clientid;
        //    this.GoodsId = goodsid;
        //    this.Cost = cost;
        //}

    }
}
