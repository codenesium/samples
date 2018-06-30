using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiChannelResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiChannelResponseModel> ByNameProjectId(string name, string projectId);

                Task<List<ApiChannelResponseModel>> ByDataVersion(byte[] dataVersion);

                Task<List<ApiChannelResponseModel>> ByProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>2e543226e4f8ad0369b4e5278eda78da</Hash>
</Codenesium>*/