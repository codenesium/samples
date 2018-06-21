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

                Task<ApiActionTemplateResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>b81b998775718ecf276000627d87025b</Hash>
</Codenesium>*/