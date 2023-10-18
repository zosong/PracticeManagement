// COP 4870 Assignment 1 Oteo Mamo

using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;

/*void DisplayMenu()
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Add Client");
    Console.WriteLine("2. Show Client/s");
    Console.WriteLine("3. Update Client");
    Console.WriteLine("4. Delete Client");
    Console.WriteLine("5. Add Project");
    Console.WriteLine("6. Show Project/s");
    Console.WriteLine("7. Update Project");
    Console.WriteLine("8. Delete Project");
    Console.WriteLine("9. Link Project to Client");
    Console.WriteLine("X. Exit!!!");
    Console.WriteLine();
}*/


/*bool exit = false;
Client clientManagement = new Client();
Project projectManagement = new Project();

while (!exit)
{
    DisplayMenu();

    Console.WriteLine("Enter your choice: ");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            clientManagement.AddClient();
            Console.WriteLine();
            break;
        case "2":
            Console.WriteLine("Showing Client/s");
            clientManagement.ReadClients();
            Console.WriteLine();
            break;
        case "3":
            clientManagement.UpdateClient();
            Console.WriteLine();
            break;
        case "4":
            Console.WriteLine("Delete Client");
            Console.WriteLine("Enter Client Id:");
            int deleteid = int.Parse(Console.ReadLine());
            clientManagement.DeleteClient(deleteid);
            break;
        case "5":
            projectManagement.AddProject();
            Console.WriteLine();
            break;
        case "6":
            Console.WriteLine("Showing Project/s");
            projectManagement.ReadProjects();
            Console.WriteLine();
            break;
        case "7":
            projectManagement.UpdateProject();
            Console.WriteLine();
            break;
        case "8":
            Console.WriteLine("Delete Project");
            Console.WriteLine("Enter Project Id:");
            int deletePid = int.Parse(Console.ReadLine());
            projectManagement.DeleteProject(deletePid);
            break;
        case "9":
            Console.WriteLine("Linking Project object to Client object");
            foreach (var project in Project.ProjectList)
            {
                Client findClient = Client.ClientList.Find(client => client.Id == project.ClientId);

                if (findClient != null)
                {
                    Console.WriteLine($"Project ID: {project.Id}");
                    Console.WriteLine($"Project ClientID: {project.ClientId}");
                    Console.WriteLine($"Client ID: {findClient.Id}");
                    Console.WriteLine($"Client: {findClient.Name}");
                    Console.WriteLine($"Project Short Name: {project.ShortName}");
                    Console.WriteLine($"Project Long Name: {project.LongName}");
                }
                Console.WriteLine();
            }
            break;
           
        case "X":
            exit = true;
            Console.WriteLine("Exiting the program...");
            break;
        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }

    Console.WriteLine();
}*/
