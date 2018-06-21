using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLCountryRegionCurrencyMapper
        {
                BOCountryRegionCurrency MapModelToBO(
                        string countryRegionCode,
                        ApiCountryRegionCurrencyRequestModel model);

                ApiCountryRegionCurrencyResponseModel MapBOToModel(
                        BOCountryRegionCurrency boCountryRegionCurrency);

                List<ApiCountryRegionCurrencyResponseModel> MapBOToModel(
                        List<BOCountryRegionCurrency> items);
        }
}

/*<Codenesium>
    <Hash>fb48d53b3ec29529f5fa84f7cbd32d62</Hash>
</Codenesium>*/