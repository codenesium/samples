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

                Task<List<ApiInvitationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>706bd1fbecde5a58e47d07528955c133</Hash>
</Codenesium>*/