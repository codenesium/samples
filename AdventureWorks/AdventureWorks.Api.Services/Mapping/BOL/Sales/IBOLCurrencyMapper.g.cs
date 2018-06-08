using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLCurrencyMapper
        {
                BOCurrency MapModelToBO(
                        string currencyCode,
                        ApiCurrencyRequestModel model);

                ApiCurrencyResponseModel MapBOToModel(
                        BOCurrency boCurrency);

                List<ApiCurrencyResponseModel> MapBOToModel(
                        List<BOCurrency> items);
        }
}

/*<Codenesium>
    <Hash>18bb1c146cdc5bf9824f3824edc0d543</Hash>
</Codenesium>*/