using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DAL
{
    public class ManagerRepository:IModelRepository<ModelsFromEntity.Manager> 
    {
        private DBModel.DBModelContext context = new DBModel.DBModelContext();
        private  DBModel.Manager ToEntity(ModelsFromEntity.Manager source)
        {
            return new DBModel.Manager() { Id = source.Id, FirstName = source.FirstName }; 
        }
        private  ModelsFromEntity.Manager ToObject(DBModel.Manager source)
        {
            return new ModelsFromEntity.Manager() { Id = source.Id, FirstName = source.FirstName };
        }
        
        public void Add(ModelsFromEntity.Manager item)
        {
            var itemToEntity = this.ToEntity(item);
            
            context.ManagerSet.Add(itemToEntity);
        }

        public void Remove(ModelsFromEntity.Manager item)
        {
            var itemToEntity = this.ToEntity(item);
            context.ManagerSet.Remove(itemToEntity);
        }

        public void Update(ModelsFromEntity.Manager item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ModelsFromEntity.Manager> Items
        {
            get 
            {
                foreach (var u in this.context.ManagerSet)
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
