using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiEmployeeModelMapper
        {
                ApiEmployeeResponseModel MapRequestToResponse(
                        int id,
                        ApiEmployeeRequestModel request);

                ApiEmployeeRequestModel MapResponseToRequest(
                        ApiEmployeeResponseModel response);

                JsonPatchDocument<ApiEmployeeRequestModel> CreatePatch(ApiEmployeeRequestModel model);
        }
}

/*<Codenesium>
    <Hash>f7905b6b917351526ff2ebb8d672905e</Hash>
</Codenesium>*/