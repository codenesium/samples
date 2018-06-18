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

                Task<List<ApiProjectResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiProjectResponseModel> GetName(string name);
                Task<ApiProjectResponseModel> GetSlug(string slug);
                Task<List<ApiProjectResponseModel>> GetDataVersion(byte[] dataVersion);
                Task<List<ApiProjectResponseModel>> GetDiscreteChannelReleaseId(bool discreteChannelRelease, string id);
        }
}

/*<Codenesium>
    <Hash>c7bcccd62238468e4e08fe51bd9e1816</Hash>
</Codenesium>*/