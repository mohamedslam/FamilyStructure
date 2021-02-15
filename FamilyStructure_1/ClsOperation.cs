using FamilyStructure_1.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyStructure_1
{
    public static class ClsOperation
    {
        static ClsFamilyData _ClsFamily = new ClsFamilyData();
        static   ClsPersonalInfo _DataPerson;

        public static void DisplayAllRelationId()
        {
            Console.Write("Select Relation Type: \n");
            ClsPersonalInfo.RelationlistName _typeRelation = ClsPersonalInfo.RelationlistName.Person;
            var _enum = Enum.GetNames(_typeRelation.GetType());
            for (int i = 0; i < _enum.Length; i++)
                Console.Write(i.ToString() + " " + _enum[i] + "\n");
        }
        public static int Count
        {
            get { return _ClsFamily.PersonsDataList.Count(); }
        }
        public static int NewId
        {
            get
            {
                if (Count != 0)
                    return _ClsFamily.PersonsDataList.Last().Id + 1;
                else
                    return 1;
            }
        } 
 
        public static List<ClsPersonalInfo>  GetPerson(string Name)
        {
            var _rst = new List<ClsPersonalInfo>(); 
            ///////////Find By Name
             
                _rst = _ClsFamily.FindPerson(Name); 
          
            return _rst;
            ///////////////////////////////////////////////////////////
        }
        public static List<ClsPersonalInfo> GetPerson(int RelationId)
        {
            var _rst = new List<ClsPersonalInfo>();
            
            ///////////Find By RelationId
            
                _rst = _ClsFamily.FindPerson((ClsPersonalInfo.RelationlistName)RelationId);
            return _rst;
            ///////////////////////////////////////////////////////////
        }
        public static bool AddNewPerson(ClsPersonalInfo _DataPerson)
        {

            /////////Add new Member To Family ///////
            return _ClsFamily.AddPerson(_DataPerson);
            /////////////////////////////////////////////////////////////////////////////////////////
           

        }
        public static bool DeletePerson(int Id)
        {

            var Person = _ClsFamily.PersonsDataList.FirstOrDefault(m => m.Id == Id);
            ///////////////////////////////////////////////////////////////////////////////
            ///
            return _ClsFamily.DeletePerson(Person);

            //////////////////////////////////////////////////////////////////////////////
        }
        public static List<ClsPersonalInfo> DisplayRelation(int IdRelation)
        {

            ClsPersonalInfo.RelationlistName _Relation = (ClsPersonalInfo.RelationlistName)IdRelation;
            var _list = _ClsFamily.PersonsDataList.Where(m => m.RelationName == _Relation).ToList();

            return _list;
        }
        public static bool Save()
        {
            return _ClsFamily.SaveData(_ClsFamily.PersonsDataList);
        }
        public static ClsPersonalInfo.GenderType GetGenderEnum(int G)
            {
            if (G == 0)
                return _DataPerson.Gender = ClsPersonalInfo.GenderType.Female;
            else if (G == 1)
                return _DataPerson.Gender = ClsPersonalInfo.GenderType.Male;
            else
                return ClsPersonalInfo.GenderType.Unknown;
        }

    }
}
