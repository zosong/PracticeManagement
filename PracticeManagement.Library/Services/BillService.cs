using Newtonsoft.Json;
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class BillService
    {

        private static BillService? instance;

        private List<BillDTO> bills;

        public List<BillDTO> Bills
        {
            get
            {
                return bills ?? new List<BillDTO>();
            }
        }




        public static BillService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillService();
                }
                return instance;
            }
        }

        public IEnumerable<BillDTO> Search(int query)
        {

            return Bills
                .Where(p => p.ClientId == query);
        }


        private BillService()
        {
            var response = new WebRequestHandler()
                .Get("/Bill").Result;
            bills = JsonConvert
                .DeserializeObject<List<BillDTO>>(response) ??
                new List<BillDTO>();
        }


        public BillDTO? Get(int id)
        {
            return Bills.FirstOrDefault(p => p.Id == id);
        }

        public BillDTO? GetBills(int id)
        {
            return Bills.FirstOrDefault(p => p.ProjectId == id);
        }

        public void Delete(int id)
        {
            var response = new WebRequestHandler()
                .Delete($"/Bill/Delete/{id}").Result;
            if (response == "SUCCESS")
            {
                var billToDelete = bills.FirstOrDefault(c => c.Id == id);
                if (billToDelete != null)
                {
                    bills.Remove(billToDelete);
                }
            }
        }

        public void AddOrUpdate(BillDTO p)
        {
            var response = new WebRequestHandler()
                .Post("/Bill", p).Result;
            var myUpdatedBill = JsonConvert.DeserializeObject<BillDTO>(response);
            if (myUpdatedBill != null)
            {
                var existingBill = bills.FirstOrDefault(c => c.Id == myUpdatedBill.Id);
                if (existingBill == null)
                {
                    bills.Add(myUpdatedBill);
                }
                else
                {
                    var index = Bills.IndexOf(existingBill);
                    bills.RemoveAt(index);
                    bills.Insert(index, myUpdatedBill);
                }
            }
        }

        /*        private int LastId
                {
                    get
                    {
                        return Bills.Any() ? Bills.Select(b => b.Id).Max() : 0;
                    }
                }*/
    }
}


