using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface ISubscriptionService
        {
                Task<CreateResponse<ApiSubscriptionResponseModel>> Create(
                        ApiSubscriptionRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiSubscriptionRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiSubscriptionResponseModel> Get(string id);

                Task<List<ApiSubscriptionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiSubscriptionResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>e2d1d86d9c8aae5b22d0d078f32b1c26</Hash>
</Codenesium>*/