using FamilyStructure_1.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FamilyStructure_1
{
    class Program
    {
        static ClsFamilyData _ClsFamily = new ClsFamilyData();
        static  ClsPersonalInfo _DataPerson;
       
        static void DisplayAllRelationId()
        {
            Console.Write("Select Relation Type: \n");
            ClsPersonalInfo.RelationlistName _typeRelation = ClsPersonalInfo.RelationlistName.Person;
            var _enum = Enum.GetNames(_typeRelation.GetType());
            for (int i = 0; i < _enum.Length; i++)
                Console.Write(i.ToString() + " " + _enum[i] + "\n");
        }
        static void AddNewPerson()
        {
            int newId = 1;
            _DataPerson = new ClsPersonalInfo();

            if (_ClsFamily.PersonsDataList.Count() != 0)
                newId = _ClsFamily.PersonsDataList.Last().Id + 1;
            _DataPerson.Id = newId;
            Console.Write("First Name: ");
            _DataPerson.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            _DataPerson.LastName = Console.ReadLine();
            d:
            try
            {
              Console.Write("BirthDate Without Any Space And Format like >> '30/02/2015' : ");
             _DataPerson.BirthDate = DateTime.Parse(Console.ReadLine());
            }
            catch  
            {
                Console.Write("Not Write Format insert like that>> '30/02/2015' : ");
                goto d;
            }
            
            Console.Write("Gender 1 for Male 0 For Femal: ");
            int G = int.Parse(Console.ReadLine());
            if (G == 0)
                _DataPerson.Gender = ClsPersonalInfo.GenderType.Female;
            else if (G == 1)
                _DataPerson.Gender = ClsPersonalInfo.GenderType.Male;
            //////////With Who that Person Relation /////////////////
            //Console.Write("Relation With Id: ");
            //_DataPerson.ParantId = int.Parse(Console.ReadLine());
            ////////What Type of that Relation /////////////////
            DisplayAllRelationId();
         

            Console.Write("Insert Relation Type:");
            int relationTypeId = int.Parse(Console.ReadLine());

            _DataPerson.RelationName = (ClsPersonalInfo.RelationlistName)relationTypeId;
            /////////Add new Member To Family ///////
            _ClsFamily.AddPerson(_DataPerson);
            /////////////////////////////////////////////////////////////////////////////////////////
            Console.Write("For AddNew Person Press F1 Save Data press F6\n");

        }
        static void DeletePerson()
        {
            Console.WriteLine("Delete Data Person\nInsert The Id To Remove It");
            int Id = int.Parse(Console.ReadLine());
            var Person = _ClsFamily.PersonsDataList.FirstOrDefault(m => m.Id == Id);
            ///////////////////////////////////////////////////////////////////////////////
            if (_ClsFamily.DeletePerson(Person))
            {
                Console.WriteLine("Person Id:" + Id.ToString() + " Deleted Succefull");
            }
            else
            {
                Console.WriteLine("Person Id:" + Id.ToString() + " Deleted Failed");
            }
            //////////////////////////////////////////////////////////////////////////////
        }
        static void FindPerson(ConsoleKeyInfo Command)
        {
            var _rst = new List<ClsPersonalInfo>();
            Console.WriteLine("To Find Person By Name Press F7  Or F8  By RelationId");
            ConsoleKeyInfo SubCommand = Console.ReadKey();
            ///////////Find By Name
            if (SubCommand.Key == ConsoleKey.F7)
            {
                Console.Write("Insert FirstName or last name:");
                string _Name = Console.ReadLine();
                _rst = _ClsFamily.FindPerson(_Name);
            }
            ///////////Find By RelationId
            else if (SubCommand.Key == ConsoleKey.F8)
            {
                DisplayAllRelationId();
                Console.Write("Insert Relation Id:");
                int RelationId = int.Parse(Console.ReadLine());                
                _rst = _ClsFamily.FindPerson((ClsPersonalInfo.RelationlistName)RelationId);
            }
            //////////////Print Result For Search////////////////////////////
            foreach (var itm in _rst)
            {
                Console.WriteLine("<< Id:" + itm.Id + "\nFull Name: " + itm.LastName + "," + itm.FirstName + " >>\n");
            }
            ///////////////////////////////////////////////////////////
        }
        static void DisplayRelation(int IdRelation)
        {

            ClsPersonalInfo.RelationlistName _Relation= (ClsPersonalInfo.RelationlistName)IdRelation;
              var _list= _ClsFamily.PersonsDataList.Where(m => m.RelationName == _Relation).ToList();
            foreach (var  itm in _list )            
                Console.WriteLine("FullName: "+ itm.LastName+" "+itm.FirstName +" Gender:"+itm.Gender+"\nBirthDate: "+itm.BirthDate.ToString());
           
        }

        static void Main(string[] args)
        {
          
            //>>>>program User Interface
            ConsoleKeyInfo Command ;

            while (true)
            {

                Console.WriteLine("Main Menue Family Tree Sample\n"
                    + "==================================\n"
                    + "| F1 AddNew | "
                    + " F3  Delete | "
                    + " F4  Search | "
                    + " F5  DisplayPersonOfRelation |"
                    + " Any  Key To finished |");
                Command = Console.ReadKey();
                ////////////////////////////////////////
                if (Command.Key == ConsoleKey.F1)
                {
                    Console.WriteLine("Add New Person\n");
                /////////////////////////////////////////////////////////////////////////////////////////
                AddPoint:
                    AddNewPerson();

                    Command = Console.ReadKey();
                    ///////////////////////////////////////////////////////////////////////////////////
                    if (Command.Key == ConsoleKey.F1)
                        goto AddPoint;
                    ////////////////////////////////////////////////////////////////////////////////////
                    else if (Command.Key == ConsoleKey.F6)
                    {
                        if (_ClsFamily.SaveData(_ClsFamily.PersonsDataList))
                            Console.Write("Saved All Data To file \n");
                        else
                            Console.Write("Data Fail To Save\n");
                        
                    }
                }

                else if (Command.Key == ConsoleKey.F3)
                {
                    DeletePerson();
                    Console.WriteLine("Press F12 To Main Menu");
                    Command = Console.ReadKey();
                    if (Command.Key == ConsoleKey.F12)
                    {
                        Console.Clear();
                       
                    }
                }
                else if (Command.Key == ConsoleKey.F4)
                {
                    FindPerson(Command);
                    Console.WriteLine("Press F12 To Main Menu");
                    Command = Console.ReadKey();
                    if (Command.Key == ConsoleKey.F12)
                    {
                        Console.Clear();
                       
                    }
                }
                else if (Command.Key == ConsoleKey.F5)
                {
                    DisplayAllRelationId();
                    int RelationId = int.Parse(Console.ReadLine());
                    DisplayRelation(RelationId);

                    Console.WriteLine("Press F12 To Main Menu");
                    Command = Console.ReadKey();
                    if (Command.Key == ConsoleKey.F12)
                    {
                        Console.Clear();
                        
                    }
                }
                else if (Command.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Good bay Mohamed Sallam");
                    break;
                }

            }
            ///////////////////////////////////////
           


            //>>>>program End User Interface
        }

        
    }
}
