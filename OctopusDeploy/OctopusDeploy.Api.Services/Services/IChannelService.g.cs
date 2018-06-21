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

                Task<ApiChannelResponseModel> GetNameProjectId(string name, string projectId);

                Task<List<ApiChannelResponseModel>> GetDataVersion(byte[] dataVersion);

                Task<List<ApiChannelResponseModel>> GetProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>8e9353cfd13dd53c17fd5ed2836ae52d</Hash>
</Codenesium>*/