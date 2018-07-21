using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiCountryModelMapper
        {
                public virtual ApiCountryResponseModel MapRequestToResponse(
                        int id,
                        ApiCountryRequestModel request)
                {
                        var response = new ApiCountryResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiCountryRequestModel MapResponseToRequest(
                        ApiCountryResponseModel response)
                {
                        var request = new ApiCountryRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }

                public JsonPatchDocument<ApiCountryRequestModel> CreatePatch(ApiCountryRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiCountryRequestModel>();
                        patch.Replace(x => x.Name, model.Name);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>348c02951a23aa77c2c6a43c9e928d8e</Hash>
</Codenesium>*/