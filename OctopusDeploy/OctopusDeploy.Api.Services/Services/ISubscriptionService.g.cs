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

                Task<List<ApiSubscriptionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiSubscriptionResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>c54cfa2145799bf50fdc01c7d74123e7</Hash>
</Codenesium>*/