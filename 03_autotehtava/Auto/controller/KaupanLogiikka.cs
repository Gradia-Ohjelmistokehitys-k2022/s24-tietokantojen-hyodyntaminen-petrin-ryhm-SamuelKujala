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
            bool didItGoIntoDatabase = dbModel.saveAutoIntoDatabase(newAuto);
            return didItGoIntoDatabase;
        }

        public List<AutonMerkki> getAllAutoMakers() {

            return dbModel.getAllAutoMakersFromDatabase();
        }

        public List<AutonMalli> getAutoModels(int makerId) 
        {

            return dbModel.getAutoModelsByMakerId(makerId);
        }

        public List<Polttoaine> getAutoPolttoaine(int makerId, int modelId, int variId) 
        {
            return dbModel.getAutoPolttoaineId(makerId, modelId, variId);
        }


        public List<Varit> getAutoVari(int makerId, int modelId)
        {
            return dbModel.getAutoVari(makerId, modelId);
        }
    }
}
