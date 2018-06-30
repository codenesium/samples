using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiUsersModelMapper
        {
                public virtual ApiUsersResponseModel MapRequestToResponse(
                        int id,
                        ApiUsersRequestModel request)
                {
                        var response = new ApiUsersResponseModel();
                        response.SetProperties(id,
                                               request.AboutMe,
                                               request.AccountId,
                                               request.Age,
                                               request.CreationDate,
                                               request.DisplayName,
                                               request.DownVotes,
                                               request.EmailHash,
                                               request.LastAccessDate,
                                               request.Location,
                                               request.Reputation,
                                               request.UpVotes,
                                               request.Views,
                                               request.WebsiteUrl);
                        return response;
                }

                public virtual ApiUsersRequestModel MapResponseToRequest(
                        ApiUsersResponseModel response)
                {
                        var request = new ApiUsersRequestModel();
                        request.SetProperties(
                                response.AboutMe,
                                response.AccountId,
                                response.Age,
                                response.CreationDate,
                                response.DisplayName,
                                response.DownVotes,
                                response.EmailHash,
                                response.LastAccessDate,
                                response.Location,
                                response.Reputation,
                                response.UpVotes,
                                response.Views,
                                response.WebsiteUrl);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>9bec43335ddb7f27b4f2f4702f22a9b6</Hash>
</Codenesium>*/