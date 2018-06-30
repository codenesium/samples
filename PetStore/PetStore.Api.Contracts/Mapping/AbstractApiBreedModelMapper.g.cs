using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Contracts
{
        public abstract class AbstractApiBreedModelMapper
        {
                public virtual ApiBreedResponseModel MapRequestToResponse(
                        int id,
                        ApiBreedRequestModel request)
                {
                        var response = new ApiBreedResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiBreedRequestModel MapResponseToRequest(
                        ApiBreedResponseModel response)
                {
                        var request = new ApiBreedRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>f030cd0a398bbb234e36cf75b616941a</Hash>
</Codenesium>*/