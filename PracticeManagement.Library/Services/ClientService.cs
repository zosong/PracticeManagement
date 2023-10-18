using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using PracticeManagement.Library.Utilities;
using PracticeManagement.Library.DTO;
using System.Diagnostics;

namespace PracticeManagement.Library.Services
{
    public class ClientService
    {
        private static ClientService? instance;

        public List<ClientDTO> Clients
        {
            get
            {
/*                var response = new WebRequestHandler()
                    .Get("/Client").Result;
                var clients = JsonConvert
                    .DeserializeObject<List<ClientDTO>>(response);
                return clients ?? new List<ClientDTO>();*/
                return clients ?? new List<ClientDTO>();
            }
        }

        private List<ClientDTO> clients;


        public IEnumerable<ClientDTO> Search(string query)
        {
            return Clients
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }

        public static ClientService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientService();
                }

                return instance;
            }
        }

      private ClientService()
        {
            var response = new WebRequestHandler()
                     .Get("/Client").Result;
             clients = JsonConvert
                    .DeserializeObject<List<ClientDTO>>(response) ?? new List<ClientDTO>();
        }



        public ClientDTO? Get(int id)
        {
            return Clients.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var response = new WebRequestHandler()
                .Delete($"/Client/Delete/{id}").Result;

            if (response == "SUCCESS")
            {
                var clientToDelete = clients.FirstOrDefault(c => c.Id == id);
                if (clientToDelete != null)
                {
                    clients.Remove(clientToDelete);
                }
            }
        }

        public void AddOrUpdate(ClientDTO c)
        {
            var response = new WebRequestHandler().Post("/Client", c).Result;
            var myUpdatedClient = JsonConvert.DeserializeObject<ClientDTO>(response);
            if (myUpdatedClient != null)
            {
                var existingClient = clients.FirstOrDefault(c => c.Id == myUpdatedClient.Id);
                if (existingClient == null)
                {
                    clients.Add(myUpdatedClient);
                }
                else
                {
                    var index = clients.IndexOf(existingClient);
                    clients.RemoveAt(index);
                    clients.Insert(index, myUpdatedClient);
                }
            }
        }
    }
}
