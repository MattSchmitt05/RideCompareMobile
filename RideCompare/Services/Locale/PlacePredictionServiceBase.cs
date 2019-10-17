using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace RideCompare.Services.Locale
{
    internal abstract class PlacePredictionServiceBase
    {
        public async Task<ObservableCollection<string>> GetPredictionsAsync(string searchText) => await GetPredictionsAsyncCore(searchText);

        protected abstract Task<ObservableCollection<string>> GetPredictionsAsyncCore(string searchText);
    }
}
