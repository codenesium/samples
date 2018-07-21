using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IProjectGroupService
        {
                Task<CreateResponse<ApiProjectGroupResponseModel>> Create(
                        ApiProjectGroupRequestModel model);

                Task<UpdateResponse<ApiProjectGroupResponseModel>> Update(string id,
                                                                           ApiProjectGroupRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiProjectGroupResponseModel> Get(string id);

                Task<List<ApiProjectGroupResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiProjectGroupResponseModel> ByName(string name);

                Task<List<ApiProjectGroupResponseModel>> ByDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>3e9e88e4fb4f145dd82181e6fb033e84</Hash>
</Codenesium>*/