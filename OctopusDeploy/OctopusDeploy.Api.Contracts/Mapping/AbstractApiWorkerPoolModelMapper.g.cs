using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiWorkerPoolModelMapper
        {
                public virtual ApiWorkerPoolResponseModel MapRequestToResponse(
                        string id,
                        ApiWorkerPoolRequestModel request)
                {
                        var response = new ApiWorkerPoolResponseModel();
                        response.SetProperties(id,
                                               request.IsDefault,
                                               request.JSON,
                                               request.Name,
                                               request.SortOrder);
                        return response;
                }

                public virtual ApiWorkerPoolRequestModel MapResponseToRequest(
                        ApiWorkerPoolResponseModel response)
                {
                        var request = new ApiWorkerPoolRequestModel();
                        request.SetProperties(
                                response.IsDefault,
                                response.JSON,
                                response.Name,
                                response.SortOrder);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>0e18bddb8849d6951e461087596f790c</Hash>
</Codenesium>*/