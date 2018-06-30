using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesTaxRateModelMapper
        {
                public virtual ApiSalesTaxRateResponseModel MapRequestToResponse(
                        int salesTaxRateID,
                        ApiSalesTaxRateRequestModel request)
                {
                        var response = new ApiSalesTaxRateResponseModel();
                        response.SetProperties(salesTaxRateID,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.Rowguid,
                                               request.StateProvinceID,
                                               request.TaxRate,
                                               request.TaxType);
                        return response;
                }

                public virtual ApiSalesTaxRateRequestModel MapResponseToRequest(
                        ApiSalesTaxRateResponseModel response)
                {
                        var request = new ApiSalesTaxRateRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name,
                                response.Rowguid,
                                response.StateProvinceID,
                                response.TaxRate,
                                response.TaxType);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>4784d4c11e8268424f0d690e5545299f</Hash>
</Codenesium>*/