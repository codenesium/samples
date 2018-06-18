using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>01088c3dd1cc752c0fc2a9118879ec08</Hash>
</Codenesium>*/