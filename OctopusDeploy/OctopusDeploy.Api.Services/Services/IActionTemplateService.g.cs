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

                Task<List<ApiActionTemplateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiActionTemplateResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>942f0288c36221ba42a36f6100983a42</Hash>
</Codenesium>*/