using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DAL
{
    public class FilesRepository:IModelRepository<ModelsFromEntity.Files> 
    {
        private DBModel.DBModelContext context = new DBModel.DBModelContext();
       
        private  DBModel.Files ToEntity(ModelsFromEntity.Files source)
        {
            return new DBModel.Files() {Id=source.Id, FileName=source.FileName}; 
        }
        
        private  ModelsFromEntity.Files ToObject(DBModel.Files source)
        {
            return new ModelsFromEntity.Files() { Id = source.Id, FileName = source.FileName };
        }

        public void Add(ModelsFromEntity.Files item)
        {
            var itemToEntity = this.ToEntity(item);
            context.FilesSet.Add(itemToEntity);
            SaveChanges();
        }

        //public void Remove(ModelsFromEntity.Client item)
        //{
        //    var itemToEntity = this.ToEntity(item);
        //    context.ClientSet.Remove(itemToEntity);
        //}

        //public void Update(ModelsFromEntity.Client item)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<ModelsFromEntity.Files> Items
        {
            get 
            {
                foreach (var u in this.context.FilesSet)
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
