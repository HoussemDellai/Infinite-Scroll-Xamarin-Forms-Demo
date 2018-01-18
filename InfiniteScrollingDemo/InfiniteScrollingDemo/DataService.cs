using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfiniteScrollingDemo
{
    public class DataService
    {
        private readonly List<string> _data = new List<string>
        {
            "Mohamed", "Hassen", "Omar", "Ali", "Othman", "Adam", "Seif", "Hamed", "Paul",
            "David", "Fehmi", "Badr", "Hamza", "Nabil", "Hajer", "Sami", "Ahmed", "Amir",
            "Nebrass", "Karim", "Cherif", "Alaa", "Samar", "Narjess", "Iheb", "Safa",
            "Mohamed", "Hassen", "Omar", "Ali", "Othman", "Adam", "Seif", "Hamed", "Paul",
            "David", "Fehmi", "Badr", "Hamza", "Nabil", "Hajer", "Sami", "Ahmed", "Amir",
        };

        public async Task<List<string>> GetItemsAsync(int pageIndex, int pageSize)
        {
            await Task.Delay(2000);

            return _data.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
}