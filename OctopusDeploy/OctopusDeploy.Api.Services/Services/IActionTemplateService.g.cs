using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>b87a6b35bc581d23e396554e937a48d3</Hash>
</Codenesium>*/