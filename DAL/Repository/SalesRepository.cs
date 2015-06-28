using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DAL
{
    public class SalesRepository:IModelRepository<ModelsFromEntity.Sales> 
    {
        private DBModel.DBModelContext context = new DBModel.DBModelContext();

        private  DBModel.Sales ToEntity(ModelsFromEntity.Sales source)
        {
            return new DBModel.Sales() 
               {Id=source.Id, ManagerId = source.ManagerId, 
                GoodsId = source.GoodsId, ClientId = source.ClientId, 
                Date = source.Date, Cost = source.Cost }; 
        }
        private  ModelsFromEntity.Sales ToObject(DBModel.Sales source)
        {
            return new ModelsFromEntity.Sales() 
                {Id = source.Id, ManagerId = source.ManagerId, 
                 GoodsId = source.GoodsId, ClientId = source.ClientId, 
                 Date = source.Date, Cost = source.Cost };
        }

        public void Add(ModelsFromEntity.Sales item)
        {
            var itemToEntity = this.ToEntity(item);
            context.SalesSet.Add(itemToEntity);
            SaveChanges();
        }

        //public void Remove(ModelsFromEntity.Sales item)
        //{
        //    var itemToEntity = this.ToEntity(item);
        //    context.SalesSet.Remove(itemToEntity);
        //}

        //public void Update(ModelsFromEntity.Sales item)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<ModelsFromEntity.Sales> Items
        {
            get 
            {
                foreach (var i in this.context.SalesSet)
                {
                    yield return this.ToObject(i);
                }
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
