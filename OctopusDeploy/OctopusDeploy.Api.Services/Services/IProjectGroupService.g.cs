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

                Task<List<ApiProjectGroupResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiProjectGroupResponseModel> GetName(string name);
                Task<List<ApiProjectGroupResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>e5b4d584c34c76e2496676c49f43fd1c</Hash>
</Codenesium>*/