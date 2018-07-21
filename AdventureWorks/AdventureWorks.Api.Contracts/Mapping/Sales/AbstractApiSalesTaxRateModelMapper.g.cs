using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiSalesTaxRateRequestModel> CreatePatch(ApiSalesTaxRateRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiSalesTaxRateRequestModel>();
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        patch.Replace(x => x.StateProvinceID, model.StateProvinceID);
                        patch.Replace(x => x.TaxRate, model.TaxRate);
                        patch.Replace(x => x.TaxType, model.TaxType);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>9ceef0c6576e1894999eb1eb30128610</Hash>
</Codenesium>*/