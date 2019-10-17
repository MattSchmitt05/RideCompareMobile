using System;
using System.Collections.Generic;
using System.Text;

namespace RideCompare.Services.ConfigurationProvider
{
    internal abstract class ConfigurationProviderBase
    {
        public string GetPlacePredictionApiKey() => GetPlacePredictionApiKeyCore();

        protected abstract string GetPlacePredictionApiKeyCore();
    }
}
