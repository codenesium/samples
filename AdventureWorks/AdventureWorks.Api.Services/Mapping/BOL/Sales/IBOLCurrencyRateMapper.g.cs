using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>614dcd27e67ddbdf80e5bb62a3e898a3</Hash>
</Codenesium>*/