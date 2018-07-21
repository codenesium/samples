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

                Task<UpdateResponse<ApiChannelResponseModel>> Update(string id,
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
    <Hash>09e282814fee96302740ca99f0f65df5</Hash>
</Codenesium>*/