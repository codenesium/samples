using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IActionTemplateVersionService
        {
                Task<CreateResponse<ApiActionTemplateVersionResponseModel>> Create(
                        ApiActionTemplateVersionRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiActionTemplateVersionRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiActionTemplateVersionResponseModel> Get(string id);

                Task<List<ApiActionTemplateVersionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiActionTemplateVersionResponseModel> GetNameVersion(string name, int version);

                Task<List<ApiActionTemplateVersionResponseModel>> GetLatestActionTemplateId(string latestActionTemplateId);
        }
}

/*<Codenesium>
    <Hash>e28e2a550372a64e06a0de65bec9bb9b</Hash>
</Codenesium>*/