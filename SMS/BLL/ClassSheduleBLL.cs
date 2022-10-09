using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity; 
using System.Data;

namespace BLL
{
    
    public class ClassSheduleBLL
    {
        ClassSheduleDAL objclssDAL = new ClassSheduleDAL();

        public int InsertUpdateDelete_InstituteBLL(List<EClassShedule> collection)
        {
            int ret = 0;
            ret = objclssDAL.InsertClassShedule(collection);
            return ret;
        }
       
    }
}
