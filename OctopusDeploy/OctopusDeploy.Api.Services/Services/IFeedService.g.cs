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

                Task<UpdateResponse<ApiFeedResponseModel>> Update(string id,
                                                                   ApiFeedRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiFeedResponseModel> Get(string id);

                Task<List<ApiFeedResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiFeedResponseModel> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>5c0062d01c605889663eb2088c670cb3</Hash>
</Codenesium>*/