using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
        public interface IApiPenModelMapper
        {
                ApiPenResponseModel MapRequestToResponse(
                        int id,
                        ApiPenRequestModel request);

                ApiPenRequestModel MapResponseToRequest(
                        ApiPenResponseModel response);

                JsonPatchDocument<ApiPenRequestModel> CreatePatch(ApiPenRequestModel model);
        }
}

/*<Codenesium>
    <Hash>77aaf2f846af06f3cf4832bcbef17fa7</Hash>
</Codenesium>*/