using Auto.model;
using Autokauppa.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokauppa.controller
{

    
    public class KaupanLogiikka
    {
        DatabaseHallinta dbModel = new DatabaseHallinta();

        public bool TestDatabaseConnection()
        {
            bool doesItWork = dbModel.connectDatabase();
            return doesItWork;
        }

        public bool saveAuto(model.Auto newAuto) 
        {
            return dbModel.saveAutoIntoDatabase(newAuto);
        }

        public bool DeleteAuto(model.Auto auto)
        {
            return dbModel.RemoveAutoFromDatabase(auto);
        }

        public List<AutonMerkki> getAllAutoMakers() {

            return dbModel.getAllAutoMakersFromDatabase();
        }

        public List<AutonMalli> getAutoModels(int makerId) 
        {

            return dbModel.getAutoModelsByMakerId(makerId);
        }

        public List<Polttoaine> getAutoPolttoaine() 
        {
            return dbModel.getAutoPolttoaineId();
        }


        public List<Varit> getAutoVari()
        {
            return dbModel.getAutoVari();
        }

        public bool CheckCar(model.Auto auto)
        {
            return dbModel.CheckIfAutoExist(auto);
        }

        public List<model.Auto> GetAllAuto()
        {
            return dbModel.GetallAutoFromDatabase();
        }

        public List<AutonMalli> GetModelsByID(int id)
        {
            return dbModel.getAutoModelsById(id);
        }


    }
}
