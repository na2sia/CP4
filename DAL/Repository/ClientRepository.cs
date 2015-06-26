using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DAL
{
    public class ClientRepository:IModelRepository<ModelsFromEntity.Client> 
    {
        private DBModel.DBModelContext context = new DBModel.DBModelContext();
        private  DBModel.Client ToEntity(ModelsFromEntity.Client source)
        {
            return new DBModel.Client() {Id=source.Id, FirstName=source.FirstName, LastName=source.LastName}; 
        }
        private  ModelsFromEntity.Client ToObject(DBModel.Client source)
        {
            return new ModelsFromEntity.Client() { Id = source.Id, FirstName = source.FirstName, LastName = source.LastName };
        }

        public void Add(ModelsFromEntity.Client item)
        {
            var itemToEntity = this.ToEntity(item);
            context.ClientSet.Add(itemToEntity);
        }

        public void Remove(ModelsFromEntity.Client item)
        {
            var itemToEntity = this.ToEntity(item);
            context.ClientSet.Remove(itemToEntity);
        }

        public void Update(ModelsFromEntity.Client item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ModelsFromEntity.Client> Items
        {
            get 
            {
                foreach (var u in this.context.ClientSet)
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
