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

                Task<List<ApiActionTemplateVersionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiActionTemplateVersionResponseModel> GetNameVersion(string name, int version);
                Task<List<ApiActionTemplateVersionResponseModel>> GetLatestActionTemplateId(string latestActionTemplateId);
        }
}

/*<Codenesium>
    <Hash>f938ac12c6a4d4a2eac9382b39bee6b8</Hash>
</Codenesium>*/