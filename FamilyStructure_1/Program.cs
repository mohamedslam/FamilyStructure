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
                AddPoint:
                    ClsOperation.AddNewPerson();

                    Command = Console.ReadKey();
                    ///////////////////////////////////////////////////////////////////////////////////
                    if (Command.Key == ConsoleKey.F1)
                        goto AddPoint;
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
                    ClsOperation.DeletePerson();
                    Console.WriteLine("Press F12 To Main Menu");
                    Command = Console.ReadKey();
                    if (Command.Key == ConsoleKey.F12)
                    {
                        Console.Clear();
                       
                    }
                }
                else if (Command.Key == ConsoleKey.F4)
                {
                    ClsOperation.GetPerson(Command);
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
                    ClsOperation.DisplayRelation(RelationId);

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
