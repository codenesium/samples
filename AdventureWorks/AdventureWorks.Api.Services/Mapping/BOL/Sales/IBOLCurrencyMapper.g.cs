using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>777121ae6dfde9fe76c0c7689b31fc63</Hash>
</Codenesium>*/