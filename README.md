# Kurnaz Sql Connector
This package allows you to easily manage your sql operations. In addition, we do not believe that orm should be used in many projects. Kurnaz Sql Connector can be easily learned and does not require knowing any sql query.
<br/>
The parameter values ​​you have given to the methods are converted to the sql query immediately. You can try this quick solution right away. I claim that you will learn in 10 minutes and complete your first project in 30 minutes.

> The development process of this package continues. Please do not use it at this stage. I will notify you when the first version is released, I promise.

<br/>

> **Nuget :** https://www.nuget.org/packages/KurnazSqlConnector <br/>

> **Tutorial (English) :** Coming Soon...

> **Tutorial (Turkish) :** Coming Soon...


## Installation

- Download this package to your project.
```bash
Install-Package KurnazSqlConnector -Version 1.0.0
```

## Examples
[Example-1 : .Net Core Web App School Admin App](https://github.com/berkekurnaz/kavram-package/tree/master/Kavram.TestConsole) <br/>

## How to use this package ?
-  This sample code contains almost all examples.
```csharp

			/* I created new database Connection */
            Connector<Person> connector = new Connector<Person>(@"Data Source=DESKTOP-DF3RRQ5;Initial Catalog=DbStajyerMuhendis;Integrated Security=True");

            // Add Operations
            string[] addAreas = { "Name", "Title" };
            string[] addParameters = { "Berke Kurnaz", "Software Engineer" };
            bool addState = connector.AddWithSqlQuery("Tests", addAreas, addParameters);
            Console.WriteLine("Add Operations was succesful : " + addState.ToString());

			// Update Operations
            string[] addAreas = { "Name", "Title" };
            string[] addParameters = { "Berke Kurnaz", "Software Engineer" };
            bool updateState = connector.UpdateWithSqlQuery("Tests", addAreas, addParameters , "Id" , "2");
            Console.WriteLine("Update Operations was succesful : " + updateState.ToString());

			// Delete Operations 
            string deleteArea = "Id";
            string deleteParameter = "4";
            bool deleteState = connector.DeleteWithSqlQuery("Tests", deleteArea, deleteParameter);
            Console.WriteLine("Delete Operations was succesful : " + deleteState.ToString());

			// List Operations
            List<Person> mylist = connector.List("Tests");
            foreach (var item in mylist)
            {
                Console.WriteLine("Id : " + item.Id + " Name : " + item.Name + " Title : " + item.Title);
            }

```

## Functions List
- T List(String key)
- bool AddWithSqlQuery(string tableName, string[] areas, string[] parameters)
- bool UpdateWithSqlQuery(string tableName, string[] areas, string[] parameters, string deleteArea, string deleteParameter)
- bool bool DeleteWithSqlQuery(string tableName, string area, string parameter)
- bool DeleteWithSqlQuery(string tableName, string area, string parameter)

## Contact
> Developer: Berke Kurnaz

> Mail Address: contact@berkekurnaz.com <br/>
> Mail Address: kurnaz.berke1907@gmail.com

> Github: https://github.com/berkekurnaz