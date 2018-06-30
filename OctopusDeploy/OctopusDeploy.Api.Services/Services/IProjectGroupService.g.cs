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

                Task<ApiProjectGroupResponseModel> ByName(string name);

                Task<List<ApiProjectGroupResponseModel>> ByDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>2f46d03d1c719c209e8c0ccc52e9e651</Hash>
</Codenesium>*/