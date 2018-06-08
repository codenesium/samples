using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>0a83da03dc65e9eafd40a0ebe17a0893</Hash>
</Codenesium>*/