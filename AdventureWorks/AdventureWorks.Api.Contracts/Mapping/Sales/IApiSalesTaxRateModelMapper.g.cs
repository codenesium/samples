using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesTaxRateModelMapper
        {
                ApiSalesTaxRateResponseModel MapRequestToResponse(
                        int salesTaxRateID,
                        ApiSalesTaxRateRequestModel request);

                ApiSalesTaxRateRequestModel MapResponseToRequest(
                        ApiSalesTaxRateResponseModel response);

                JsonPatchDocument<ApiSalesTaxRateRequestModel> CreatePatch(ApiSalesTaxRateRequestModel model);
        }
}

/*<Codenesium>
    <Hash>b4757d989e64c92e9ff49724a9f493be</Hash>
</Codenesium>*/