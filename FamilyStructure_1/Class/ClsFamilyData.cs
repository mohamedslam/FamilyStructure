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
    public class ClsFamilyData : IFamily_Members
    {
        public List<ClsPersonalInfo> PersonsDataList;

        public ClsFamilyData()
        {
            PersonsDataList = new List<ClsPersonalInfo>() {
          new ClsPersonalInfo()
          {
              Id = 1, Gender =  GenderType.Male, FirstName = "Mohamed", LastName = "Sallam",  RelationName = ClsPersonalInfo.RelationlistName.Person, BirthDate = DateTime.Parse("02/02/1980")
          },
          new ClsPersonalInfo()
          {
              Id = 2, Gender = GenderType.Male , FirstName = "Alsayied", LastName = "Sallam",   RelationName = ClsPersonalInfo.RelationlistName.Father,   BirthDate = DateTime.Parse("10/11/1985")
          },
          new ClsPersonalInfo()
          {
              Id = 3, Gender = GenderType.Female , FirstName = "Magda", LastName = "AlGohary",   RelationName = ClsPersonalInfo.RelationlistName.Mother,   BirthDate = DateTime.Parse("10/11/1985")
          },
           new ClsPersonalInfo()
          {
              Id = 4, Gender = GenderType.Male , FirstName = "Ahmed", LastName = "Sallam",    RelationName = ClsPersonalInfo.RelationlistName.Brother,   BirthDate = DateTime.Parse("10/11/1985")
          },
            new ClsPersonalInfo()
          {
              Id = 5, Gender = GenderType.Female , FirstName = "Hoda", LastName = "Sallam",  RelationName = ClsPersonalInfo.RelationlistName.Sister,   BirthDate = DateTime.Parse("10/11/1986")
          },
             new ClsPersonalInfo()
          {
              Id = 6, Gender = GenderType.Male , FirstName = "Hussien", LastName = "Sallam",  RelationName = ClsPersonalInfo.RelationlistName.GrandFather,   BirthDate = DateTime.Parse("10/11/1922")
          },
             new ClsPersonalInfo()
          {
              Id = 7, Gender = GenderType.Female , FirstName = "Fawozia", LastName = "Sallam",   RelationName = ClsPersonalInfo.RelationlistName.GrandMother,   BirthDate = DateTime.Parse("10/11/1930")
          },
             new ClsPersonalInfo()
          {
              Id = 8, Gender = GenderType.Female , FirstName = "Ksenia", LastName = "Youryvnia",  RelationName = ClsPersonalInfo.RelationlistName.Wife,   BirthDate = DateTime.Parse("15/3/1981")
          },
             new ClsPersonalInfo()
          {
              Id = 9, Gender = GenderType.Female , FirstName = "Gogo", LastName = "Mohamed",  RelationName = ClsPersonalInfo.RelationlistName.Daughter,   BirthDate = DateTime.Parse("18/02/2005")
          },
             new ClsPersonalInfo()
          {
              Id = 10, Gender = GenderType.Female , FirstName = "Mona", LastName = "Mohamed", RelationName = ClsPersonalInfo.RelationlistName.Daughter,   BirthDate = DateTime.Parse("10/07/2006")
          },
             new ClsPersonalInfo()
          {
              Id = 11, Gender = GenderType.Female , FirstName = "Mariam", LastName = "Mohamed",   RelationName = ClsPersonalInfo.RelationlistName.Daughter,   BirthDate = DateTime.Parse("10/07/2013")
          },
             new ClsPersonalInfo()
          {
              Id = 12, Gender = GenderType.Male , FirstName = "Yousef", LastName = "Mohamed",  RelationName = ClsPersonalInfo.RelationlistName.Son ,   BirthDate = DateTime.Parse("10/07/2014")
          },
              new ClsPersonalInfo()
          {
              Id = 13, Gender = GenderType.Male , FirstName = "Hesham", LastName = "Agohary",  RelationName = ClsPersonalInfo.RelationlistName.Uncle_MotherBrother ,   BirthDate = DateTime.Parse("10/07/1960")
          },
              new ClsPersonalInfo()
          {
              Id =14, Gender = GenderType.Male , FirstName = "AboAlela", LastName = "Agohary",   RelationName = ClsPersonalInfo.RelationlistName.Uncle_MotherBrother ,   BirthDate = DateTime.Parse("10/07/1950")
          },
             new ClsPersonalInfo()
          {
              Id = 15, Gender = GenderType.Male , FirstName = "Ebrahiem", LastName = "Sallam", RelationName = ClsPersonalInfo.RelationlistName.Uncle_FatherBrother ,   BirthDate = DateTime.Parse("10/07/1950")
          },
             new ClsPersonalInfo()
          {
              Id = 16, Gender = GenderType.Female , FirstName = "Sanaa", LastName = "Sallam", RelationName = ClsPersonalInfo.RelationlistName.Aunt_FatherSister ,   BirthDate = DateTime.Parse("10/07/1950")
          },
                 new ClsPersonalInfo()
          {
              Id = 17, Gender = GenderType.Female , FirstName = "Zinab", LastName = "Sallam", RelationName = ClsPersonalInfo.RelationlistName.Aunt_FatherSister ,   BirthDate = DateTime.Parse("10/07/1950")
          },
             new ClsPersonalInfo()
          {
              Id = 18, Gender = GenderType.Female , FirstName = "Zinab", LastName = "Algohary", RelationName = ClsPersonalInfo.RelationlistName.Aunt_MotherSister ,   BirthDate = DateTime.Parse("10/07/1950")
          },
                new ClsPersonalInfo()
          {
              Id = 19, Gender = GenderType.Female , FirstName = "Hanaa", LastName = "Algohary", RelationName = ClsPersonalInfo.RelationlistName.Aunt_MotherSister ,   BirthDate = DateTime.Parse("10/07/1950")
          },
        new ClsPersonalInfo()
          {
              Id = 20, Gender = GenderType.Female , FirstName = "KseniaMama", LastName = "Yourivna", RelationName = ClsPersonalInfo.RelationlistName.Aunt_MotherSister ,   BirthDate = DateTime.Parse("01/01/1940")
          },


            };

        }
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

        
    }
}
