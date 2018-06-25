using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IActionTemplateService
        {
                Task<CreateResponse<ApiActionTemplateResponseModel>> Create(
                        ApiActionTemplateRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiActionTemplateRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiActionTemplateResponseModel> Get(string id);

                Task<List<ApiActionTemplateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiActionTemplateResponseModel> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>0bfe2a1e7e3157915a29c50b57ed1fe9</Hash>
</Codenesium>*/