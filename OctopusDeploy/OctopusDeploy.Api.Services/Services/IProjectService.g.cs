using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IProjectService
        {
                Task<CreateResponse<ApiProjectResponseModel>> Create(
                        ApiProjectRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiProjectRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiProjectResponseModel> Get(string id);

                Task<List<ApiProjectResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiProjectResponseModel> GetName(string name);
                Task<ApiProjectResponseModel> GetSlug(string slug);
                Task<List<ApiProjectResponseModel>> GetDataVersion(byte[] dataVersion);
                Task<List<ApiProjectResponseModel>> GetDiscreteChannelReleaseId(bool discreteChannelRelease, string id);
        }
}

/*<Codenesium>
    <Hash>186b1717147c4795a071dfd62e6e81a4</Hash>
</Codenesium>*/