using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiUsersRequestModel> CreatePatch(ApiUsersRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiUsersRequestModel>();
                        patch.Replace(x => x.AboutMe, model.AboutMe);
                        patch.Replace(x => x.AccountId, model.AccountId);
                        patch.Replace(x => x.Age, model.Age);
                        patch.Replace(x => x.CreationDate, model.CreationDate);
                        patch.Replace(x => x.DisplayName, model.DisplayName);
                        patch.Replace(x => x.DownVotes, model.DownVotes);
                        patch.Replace(x => x.EmailHash, model.EmailHash);
                        patch.Replace(x => x.LastAccessDate, model.LastAccessDate);
                        patch.Replace(x => x.Location, model.Location);
                        patch.Replace(x => x.Reputation, model.Reputation);
                        patch.Replace(x => x.UpVotes, model.UpVotes);
                        patch.Replace(x => x.Views, model.Views);
                        patch.Replace(x => x.WebsiteUrl, model.WebsiteUrl);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>50220d04b82c2c4c79a31fd560cc5c8e</Hash>
</Codenesium>*/