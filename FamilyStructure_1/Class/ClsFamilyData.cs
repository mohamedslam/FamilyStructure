using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static FamilyStructure_1.Class.ClsPersonalInfo;

namespace FamilyStructure_1.Class
{
    public class ClsFamilyData : ClsPersonalInfo, IFamily_Members
    {
 
        public  bool AddPerson(ClsPersonalInfo Person)
        {
            bool _resut = false;
            try
            {
                PersonsDataList.Add(Person);
                _resut = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return _resut;
        }
        public bool DeletePerson(ClsPersonalInfo Person)
        {
            bool _resut = false;
            try
            {
                _resut= PersonsDataList.Remove(Person);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _resut;
        }
        public ClsPersonalInfo FindPerson(int Id)
        {
            ClsPersonalInfo _resut = new ClsPersonalInfo();
            try
            {
                _resut = PersonsDataList.FirstOrDefault(m => m.Id == Id);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _resut;
        }
        public List< ClsPersonalInfo> FindPerson(string Name)
        {
             
            try
            {
           var _resut = PersonsDataList.Where(m=>m.FirstName== Name || m.LastName==Name).ToList();
            return _resut;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
           
        }
        public List< ClsPersonalInfo> FindPerson(RelationlistName RelationType)
        {
          
            try
            {

           var     _resut = PersonsDataList.Where(m => m.RelationName == RelationType).ToList();

                return _resut;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
             
        }
        public bool UpdatePerson(ClsPersonalInfo NewPersonData)
        {
            bool _resut = false;
            try
            {
                ClsPersonalInfo _TempPersonData;
                _TempPersonData = PersonsDataList.FirstOrDefault(m => m.Id == NewPersonData.Id || (m.FirstName==NewPersonData.FirstName && m.LastName == NewPersonData.LastName) );
               
                ///Fill New Updated Data
                _TempPersonData.Id = NewPersonData.Id;
                _TempPersonData.ParantId = NewPersonData.ParantId;
                _TempPersonData.FirstName = NewPersonData.FirstName;
                _TempPersonData.LastName = NewPersonData.LastName;
                _TempPersonData.Gender = NewPersonData.Gender;
                _TempPersonData.BirthDate = NewPersonData.BirthDate;

                _resut = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _resut;
        }
        public   List<T> LoadData<T>(string fileName)
        {
            var list = new List<T>();
            // Check if we had previously Save information of our friends
            // previously
            if (File.Exists(fileName))
            {

                try
                {
                    // Create a FileStream will gain read access to the
                    // data file.
                    using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        var formatter = new BinaryFormatter();
                        list = (List<T>)
                            formatter.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return list;
        }       
        public bool SaveData<T>(T list)
        {
            // Gain code access to the file that we are going
            // to write to
            try
            {
                // Create a FileStream that will write data to file.
                using (var stream = new FileStream("SaveData.txt", FileMode.Create, FileAccess.Write))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, list);
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n"+ex.Message+"\n\n");
                return false;
            }
        }

        public bool AddFamilyMembars(int IdParant, ClsPersonalInfo _DataPerson)
        {
            var _rst = new ClsPersonalInfo();
            ///////////

            _rst = FindPerson(IdParant);
            /////////Add new Member To Family ///////
            _rst.PersonsDataList.Add(_DataPerson);
            return true;
        }
    }
}
