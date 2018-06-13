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

                Task<List<ApiInvitationResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>3a680ad0e5d1f0a52678bdbfa74a88d7</Hash>
</Codenesium>*/