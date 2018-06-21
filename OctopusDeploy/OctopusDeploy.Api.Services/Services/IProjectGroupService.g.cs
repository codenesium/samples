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

                Task<ActionResponse> Update(string id,
                                            ApiProjectGroupRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiProjectGroupResponseModel> Get(string id);

                Task<List<ApiProjectGroupResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiProjectGroupResponseModel> GetName(string name);

                Task<List<ApiProjectGroupResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>cf1262378f8012803595fd29bf6fa536</Hash>
</Codenesium>*/