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

                Task<List<ApiChannelResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiChannelResponseModel> GetNameProjectId(string name, string projectId);
                Task<List<ApiChannelResponseModel>> GetDataVersion(byte[] dataVersion);
                Task<List<ApiChannelResponseModel>> GetProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>4121edbcee97ea15c5d71a9e5e46cd6e</Hash>
</Codenesium>*/