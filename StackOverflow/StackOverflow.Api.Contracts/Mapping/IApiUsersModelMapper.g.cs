using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiUsersModelMapper
        {
                ApiUsersResponseModel MapRequestToResponse(
                        int id,
                        ApiUsersRequestModel request);

                ApiUsersRequestModel MapResponseToRequest(
                        ApiUsersResponseModel response);

                JsonPatchDocument<ApiUsersRequestModel> CreatePatch(ApiUsersRequestModel model);
        }
}

/*<Codenesium>
    <Hash>07201429c58ab1d52f8874b99432d208</Hash>
</Codenesium>*/