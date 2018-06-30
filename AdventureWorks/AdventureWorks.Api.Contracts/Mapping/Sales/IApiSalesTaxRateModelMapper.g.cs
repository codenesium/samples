using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesTaxRateModelMapper
        {
                ApiSalesTaxRateResponseModel MapRequestToResponse(
                        int salesTaxRateID,
                        ApiSalesTaxRateRequestModel request);

                ApiSalesTaxRateRequestModel MapResponseToRequest(
                        ApiSalesTaxRateResponseModel response);
        }
}

/*<Codenesium>
    <Hash>08d2a21bdbb80dfaf88eb80ee14bb08e</Hash>
</Codenesium>*/