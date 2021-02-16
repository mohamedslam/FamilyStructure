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

                     
                   var _DataPerson = new ClsPersonalInfo();
                 
                    _DataPerson.Id = ClsOperation.NewId;
                    Console.Write("First Name: ");
                    _DataPerson.FirstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    _DataPerson.LastName = Console.ReadLine();
                    try
                    {
                        Console.Write("BirthDate Without Any Space And Format like >> '30/02/2015' : ");
                        _DataPerson.BirthDate = DateTime.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.Write("Not Write Format insert like that>> '30/02/2015' : ");

                    }
                    Console.Write("Gender 1 for Male 0 For Femal: ");
                    int G = int.Parse(Console.ReadLine());
                    _DataPerson.Gender = ClsOperation.GetGenderEnum(G);

                    ClsOperation.AddNewPerson(_DataPerson);                  
                    ///////
                    ClsOperation.DisplayAllRelationId();
                    Console.Write("look for the list and Insert Relation Type No:");
                    int relationTypeId = int.Parse(Console.ReadLine());
                    _DataPerson.RelationName = (ClsPersonalInfo.RelationlistName)relationTypeId;

                    ClsOperation.AddNewPerson(_DataPerson);

                    Command = Console.ReadKey();
                    ///////////////////////////////////////////////////////////////////////////////////
                    if (Command.Key == ConsoleKey.F1)
                    { }
                    ////////////////////////////////////////////////////////////////////////////////////
                    else if (Command.Key == ConsoleKey.F6)
                    {
                        if (ClsOperation.Save())
                            Console.Write("Saved All Data To file \n");
                        else
                            Console.Write("Data Fail To Save\n");
                        
                    }
                }
                else if (Command.Key == ConsoleKey.F3)
                {

                    Console.WriteLine("Delete Data Person\nInsert The Id To Remove It");
                    int Id = int.Parse(Console.ReadLine());
                    if (ClsOperation.DeletePerson(Id))
                    {
                        Console.WriteLine("Person Id:" + Id.ToString() + " Deleted Succefull");
                    }
                    else
                    {
                        Console.WriteLine("Person Id:" + Id.ToString() + " Deleted Failed");
                    }
                    Console.WriteLine("Press F12 To Main Menu");
                    Command = Console.ReadKey();
                    if (Command.Key == ConsoleKey.F12)
                    {
                        Console.Clear();
                       
                    }
                }
                else if (Command.Key == ConsoleKey.F4)
                { 
                        var _rst = new List<ClsPersonalInfo>();
                        Console.WriteLine("To Find Person By Name Press F7  Or F8  By RelationId");
                        ConsoleKeyInfo SubCommand = Console.ReadKey();
                        ///////////Find By Name
                        if (SubCommand.Key == ConsoleKey.F7)
                        {
                            Console.Write("Insert FirstName or last name:");
                            string _Name = Console.ReadLine();
                            _rst = ClsOperation.GetPerson(_Name);
                        }
                        ///////////Find By RelationId
                        else if (SubCommand.Key == ConsoleKey.F8)
                        {
                        ClsOperation.DisplayAllRelationId();
                            Console.Write("Insert Relation Id:");
                            int RelationId = int.Parse(Console.ReadLine());
                            _rst = ClsOperation.GetPerson(RelationId);
                        }
                    foreach (var p in _rst)
                    {
                        Console.WriteLine("\nId:"+ p.Id + " FirstName:"+p.FirstName + " LastName:" + p.LastName + " Gender:" + p.Gender.ToString()  + " RelationName:" + p.RelationName.ToString());
                    }
                        Console.WriteLine("Press F12 To Main Menu");
                    Command = Console.ReadKey();
                    if (Command.Key == ConsoleKey.F12)
                    {
                        Console.Clear();
                    }



                }
                else if (Command.Key == ConsoleKey.F5)
                {
                    ClsOperation.DisplayAllRelationId();
                    int RelationId = int.Parse(Console.ReadLine());
                    foreach (var itm in ClsOperation.DisplayRelation(RelationId))
                        Console.WriteLine("FullName: " + itm.LastName + " " + itm.FirstName + " Gender:" + itm.Gender + "\nBirthDate: " + itm.BirthDate.ToString());
                 

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
