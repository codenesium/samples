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

                Task<UpdateResponse<ApiActionTemplateResponseModel>> Update(string id,
                                                                             ApiActionTemplateRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiActionTemplateResponseModel> Get(string id);

                Task<List<ApiActionTemplateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiActionTemplateResponseModel> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>936cee499da59797ba57a8c8b84d8cf3</Hash>
</Codenesium>*/