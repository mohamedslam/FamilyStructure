using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyStructure_1.Class
{
    interface IFamily_Members
    {
       
        bool  AddPerson(ClsPersonalInfo Person);

        bool DeletePerson(ClsPersonalInfo Person);

        bool UpdatePerson(ClsPersonalInfo Person);
        bool AddFamilyMembars(int IdParant, ClsPersonalInfo _DataPerson);
        List<ClsPersonalInfo> FindPerson(string Name);
        List<T> LoadData<T>(string fileName);




    }
}
