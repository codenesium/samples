using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IFeedService
        {
                Task<CreateResponse<ApiFeedResponseModel>> Create(
                        ApiFeedRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiFeedRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiFeedResponseModel> Get(string id);

                Task<List<ApiFeedResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiFeedResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>7cab24fd3260ff3437b01388c8b48839</Hash>
</Codenesium>*/