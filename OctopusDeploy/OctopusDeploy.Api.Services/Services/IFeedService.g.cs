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

                Task<List<ApiFeedResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiFeedResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>2bd5f56387ec0f36f9ff19f9a069431b</Hash>
</Codenesium>*/