using RideCompare.Services.Locale;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideCompare.Tests.AcceptanceTests.TestDoubles.Services.Locale
{
    [ExcludeFromCodeCoverage]
    internal sealed class PlacePredictionServiceSpy : PlacePredictionServiceBase
    {
        protected override Task<ObservableCollection<string>> GetPredictionsAsyncCore(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
