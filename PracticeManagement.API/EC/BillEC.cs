using PracticeManagement.API.Database;
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;

namespace PracticeManagement.API.EC
{
    public class BillEC
    {
        public BillDTO? Get(int id)
        {
            var bill = Filebase.Current.Bills.FirstOrDefault(p => p.Id == id);
            return bill != null ? new BillDTO(bill) : null;
        }

        public Bill AddOrUpdate(Bill bill)
        {
            return Filebase.Current.AddOrUpdate(bill);
        }

        public BillDTO? Delete(int id)
        {
            var billToDelete = Filebase.Current.Bills.FirstOrDefault(p => p.Id == id);
            if (billToDelete != null)
            {
                Filebase.Current.Bills.Remove(billToDelete);
            }
            return billToDelete != null ?
                new BillDTO(billToDelete)
                : null;
        }

        public IEnumerable<BillDTO> Search(string query = "")
        {
            return Filebase.Current.Bills
                .Where(c => c.Name.ToUpper()
                                   .Contains(query.ToUpper()))
                .Take(1000)
                .Select(c => new BillDTO(c));
        }
    }
}
