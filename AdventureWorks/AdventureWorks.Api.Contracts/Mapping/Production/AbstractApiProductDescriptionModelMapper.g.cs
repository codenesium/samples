using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductDescriptionModelMapper
        {
                public virtual ApiProductDescriptionResponseModel MapRequestToResponse(
                        int productDescriptionID,
                        ApiProductDescriptionRequestModel request)
                {
                        var response = new ApiProductDescriptionResponseModel();
                        response.SetProperties(productDescriptionID,
                                               request.Description,
                                               request.ModifiedDate,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiProductDescriptionRequestModel MapResponseToRequest(
                        ApiProductDescriptionResponseModel response)
                {
                        var request = new ApiProductDescriptionRequestModel();
                        request.SetProperties(
                                response.Description,
                                response.ModifiedDate,
                                response.Rowguid);
                        return request;
                }

                public JsonPatchDocument<ApiProductDescriptionRequestModel> CreatePatch(ApiProductDescriptionRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiProductDescriptionRequestModel>();
                        patch.Replace(x => x.Description, model.Description);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>05519cce6c2e1d7fdf7fa353ba413de3</Hash>
</Codenesium>*/