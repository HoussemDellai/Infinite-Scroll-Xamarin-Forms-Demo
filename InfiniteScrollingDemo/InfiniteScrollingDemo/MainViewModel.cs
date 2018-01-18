using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms.Extended;

namespace InfiniteScrollingDemo
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;
        private const int PageSize = 10;

        public InfiniteScrollCollection<string> Items { get; }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value; 
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Items = new InfiniteScrollCollection<string>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;
                    
                    // load the next page
                    var page = Items.Count / PageSize;
                    var dataService = new DataService();
                    var items = await dataService.GetItemsAsync(page + 1, PageSize);

                    IsBusy = false;

                    // return the items that need to be added
                    return items;
                }
            };

            DownloadDataAsync();
        }

        private async Task DownloadDataAsync()
        {
            var dataService = new DataService();
            var items = await dataService.GetItemsAsync(0, PageSize);
            Items.AddRange(items);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
