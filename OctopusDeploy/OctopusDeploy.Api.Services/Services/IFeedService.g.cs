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

                Task<List<ApiFeedResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiFeedResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>723f18e1ec80bc53319d1c5d47597339</Hash>
</Codenesium>*/