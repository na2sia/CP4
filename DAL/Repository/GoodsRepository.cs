using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DBModel;

namespace DAL
{
    public class GoodsRepository:IModelRepository<ModelsFromEntity.Goods> 
    {
        private DBModel.DBModelContext context = new DBModel.DBModelContext();
        private  DBModel.Goods ToEntity(ModelsFromEntity.Goods source)
        {
            return new DBModel.Goods() { Id = source.Id, Name = source.Name }; 
        }
        private  ModelsFromEntity.Goods ToObject(DBModel.Goods source)
        {
            return new ModelsFromEntity.Goods() { Id = source.Id, Name = source.Name };
        }

        public void Add(ModelsFromEntity.Goods item)
        {
            var itemToEntity = this.ToEntity(item);
            context.GoodsSet.Add(itemToEntity);
        }

        //public void Remove(ModelsFromEntity.Goods item)
        //{
        //    var itemToEntity = this.ToEntity(item);
        //    context.GoodsSet.Remove(itemToEntity);
        //}

        //public void Update(ModelsFromEntity.Goods item)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<ModelsFromEntity.Goods> Items
        {
            get 
            {
                foreach (var u in this.context.GoodsSet)
                {
                    yield return this.ToObject(u);
                }
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
