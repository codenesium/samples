using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IChannelService
        {
                Task<CreateResponse<ApiChannelResponseModel>> Create(
                        ApiChannelRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiChannelRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiChannelResponseModel> Get(string id);

                Task<List<ApiChannelResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiChannelResponseModel> GetNameProjectId(string name, string projectId);
                Task<List<ApiChannelResponseModel>> GetDataVersion(byte[] dataVersion);
                Task<List<ApiChannelResponseModel>> GetProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>aefab95f6c78b0e5a3c75ab6fdafdc31</Hash>
</Codenesium>*/