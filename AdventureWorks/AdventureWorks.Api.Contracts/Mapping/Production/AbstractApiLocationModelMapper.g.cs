using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiLocationModelMapper
        {
                public virtual ApiLocationResponseModel MapRequestToResponse(
                        short locationID,
                        ApiLocationRequestModel request)
                {
                        var response = new ApiLocationResponseModel();
                        response.SetProperties(locationID,
                                               request.Availability,
                                               request.CostRate,
                                               request.ModifiedDate,
                                               request.Name);
                        return response;
                }

                public virtual ApiLocationRequestModel MapResponseToRequest(
                        ApiLocationResponseModel response)
                {
                        var request = new ApiLocationRequestModel();
                        request.SetProperties(
                                response.Availability,
                                response.CostRate,
                                response.ModifiedDate,
                                response.Name);
                        return request;
                }

                public JsonPatchDocument<ApiLocationRequestModel> CreatePatch(ApiLocationRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiLocationRequestModel>();
                        patch.Replace(x => x.Availability, model.Availability);
                        patch.Replace(x => x.CostRate, model.CostRate);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Name, model.Name);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>0d2aa16e3a3546f0ccc9706e79bff03f</Hash>
</Codenesium>*/