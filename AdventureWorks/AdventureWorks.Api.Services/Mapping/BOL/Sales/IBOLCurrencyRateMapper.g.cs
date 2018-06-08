using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLCurrencyRateMapper
        {
                BOCurrencyRate MapModelToBO(
                        int currencyRateID,
                        ApiCurrencyRateRequestModel model);

                ApiCurrencyRateResponseModel MapBOToModel(
                        BOCurrencyRate boCurrencyRate);

                List<ApiCurrencyRateResponseModel> MapBOToModel(
                        List<BOCurrencyRate> items);
        }
}

/*<Codenesium>
    <Hash>896ca06bfea7a24b9644e8020b968577</Hash>
</Codenesium>*/