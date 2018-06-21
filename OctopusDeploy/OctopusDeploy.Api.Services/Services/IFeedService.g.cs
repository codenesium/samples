using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>ee3649e9e7d8ff64d739edc9b3478593</Hash>
</Codenesium>*/