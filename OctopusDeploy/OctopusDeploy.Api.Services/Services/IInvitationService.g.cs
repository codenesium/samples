using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IInvitationService
        {
                Task<CreateResponse<ApiInvitationResponseModel>> Create(
                        ApiInvitationRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiInvitationRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiInvitationResponseModel> Get(string id);

                Task<List<ApiInvitationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9d47e5c75b446623a1e4616ca39fe0f9</Hash>
</Codenesium>*/