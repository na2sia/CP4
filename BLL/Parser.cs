﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
        private DAL.IModelRepository<DAL.ModelsFromEntity.Files> filesRepository = new DAL.FilesRepository();
        
        private void ParseData(string fileName)
        {
            DateTime date;
            string nameManager, nameClient, nameGoods;
            double cost;

            nameManager = Path.GetFileName(fileName).Split('_')[0];
            var dateFile = DateTime.ParseExact(Path.GetFileNameWithoutExtension(fileName).Split('_')[1], "ddMMyyyy", CultureInfo.InvariantCulture);

            
            foreach (var s in File.ReadAllLines(fileName))
            {
                var field = s.Split(';');

                nameClient = field[1];
                nameGoods = field[2];
                if (!DateTime.TryParse(field[0], out date))
                    throw new InvalidDataException("Date is not DateTime");
                if (!double.TryParse(field[3], out cost))
                    throw new InvalidDataException("Cost is not double");

                var manager = managerRepository.Items.FirstOrDefault(x => x.FirstName == nameManager);
                var client = clientRepository.Items.FirstOrDefault(x => x.FirstName == nameClient);
                var goods = goodsRepository.Items.FirstOrDefault(x => x.Name == nameGoods);

                if (date != dateFile) throw new InvalidDataException("Date not match");
                
                if ((manager != null)&& (client!= null)&& (goods!= null))
                    salesRepository.Add (new DAL.ModelsFromEntity.Sales(date,manager.Id,client.Id,goods.Id,cost));
                else throw new InvalidDataException("Data not in the database");
            }
        }
        public void ParseFileName(string fileName)
        {
            if (filesRepository.Items.FirstOrDefault(x => x.FileName == Path.GetFileNameWithoutExtension(fileName)) == null)
            {
                ParseData(fileName);
                filesRepository.Add(new DAL.ModelsFromEntity.Files(Path.GetFileNameWithoutExtension(fileName)));
            }
            else throw new InvalidDataException("This file been processed");
        }

    }
}
