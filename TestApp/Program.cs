using KurnazSqlConnector;
using System;
using System.Collections.Generic;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* I created new database Connection */
            Connector<Person> connector = new Connector<Person>(@"Data Source=DESKTOP-DF3RRQ5;Initial Catalog=DbStajyerMuhendis;Integrated Security=True");

            /*
            // Add Operations
            string[] addAreas = { "Name", "Title" };
            string[] addParameters = { "Adnan Menderes", "Başbakan" };
            bool addState = connector.AddWithSqlQuery("Tests", addAreas, addParameters);
            Console.WriteLine("Add Operations was succesful : " + addState.ToString());
            */

            /*
            // Delete Operations 
            string deleteArea = "Id";
            string deleteParameter = "4";
            bool deleteState = connector.DeleteWithSqlQuery("Tests", deleteArea, deleteParameter);
            Console.WriteLine("Delete Operations was succesful : " + deleteState.ToString());
            */

            /*
            // List Operations
            List<Person> mylist = connector.List("Tests");
            foreach (var item in mylist)
            {
                Console.WriteLine("Id : " + item.Id + " Name : " + item.Name + " Title : " + item.Title);
            }
            */

            /*
            // Update Operations
            string[] addAreas = { "Name", "Title" };
            string[] addParameters = { "Adnan Menderes", "Başbakan" };
            bool updateState = connector.UpdateWithSqlQuery("Tests", addAreas, addParameters , "Id" , "2");
            Console.WriteLine("Update Operations was succesful : " + updateState.ToString());
            */


            Console.ReadLine();
        }
    }
}
