using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Parser
    {
        private DAL.IModelRepository<DAL.ModelsFromEntity.Sales> salesRepository = new DAL.SalesRepository();
        private DAL.IModelRepository<DAL.ModelsFromEntity.Manager> managerRepository = new DAL.ManagerRepository();
        private DAL.IModelRepository<DAL.ModelsFromEntity.Goods> goodsRepository = new DAL.GoodsRepository();
        private DAL.IModelRepository<DAL.ModelsFromEntity.Client> clientRepository = new DAL.ClientRepository();
        public void ParseList(string fileName)
        {
            DateTime date;
            string nameManager, nameClient, nameGoods;
            double cost;

            nameManager = Path.GetFileName(fileName).Split('_')[0];
            
            foreach (var s in File.ReadAllLines(fileName))
            { 
                var parametres = s.Split(';');
                nameClient = parametres[1];
                nameGoods = parametres[2];

                if (!DateTime.TryParse(parametres[0], out date))
                    throw new InvalidDataException("Time is not DateTime");
                
                if (!double.TryParse(parametres[3], out cost))
                    throw new InvalidDataException("Cost is not double");

                var manager = managerRepository.Items.FirstOrDefault(x => x.FirstName == nameManager);
                var client = clientRepository.Items.FirstOrDefault(x => x.FirstName == nameClient);
                var goods = goodsRepository.Items.FirstOrDefault(x => x.Name == nameGoods);
                if ((manager != null)&& (client!= null)&& (goods!= null))
                    { salesRepository.Add(new DAL.ModelsFromEntity.Sales()
                    { Cost = cost, Date = date, ClientId = client.Id, ManagerId = manager.Id, GoodsId = goods.Id }); }
                else throw new InvalidDataException("Data not in the database");

            }
            
            salesRepository.SaveChanges();
            
        }

    }
}
