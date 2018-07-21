using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiEmployeeModelMapper
        {
                ApiEmployeeResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiEmployeeRequestModel request);

                ApiEmployeeRequestModel MapResponseToRequest(
                        ApiEmployeeResponseModel response);

                JsonPatchDocument<ApiEmployeeRequestModel> CreatePatch(ApiEmployeeRequestModel model);
        }
}

/*<Codenesium>
    <Hash>ffdb9f5bd686995142700407e66afd6d</Hash>
</Codenesium>*/