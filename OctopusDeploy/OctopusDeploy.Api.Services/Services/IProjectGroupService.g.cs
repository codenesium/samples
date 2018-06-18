using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>c133d638d06b4861f5f6c6b377e0062a</Hash>
</Codenesium>*/