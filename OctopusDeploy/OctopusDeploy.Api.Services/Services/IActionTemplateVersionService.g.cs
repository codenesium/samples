using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                Task<List<ApiActionTemplateVersionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiActionTemplateVersionResponseModel> GetNameVersion(string name, int version);
                Task<List<ApiActionTemplateVersionResponseModel>> GetLatestActionTemplateId(string latestActionTemplateId);
        }
}

/*<Codenesium>
    <Hash>3a43db7bee5630e716b3e8e4422c0e65</Hash>
</Codenesium>*/