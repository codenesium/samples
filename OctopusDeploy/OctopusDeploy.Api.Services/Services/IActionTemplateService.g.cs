using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IActionTemplateService
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
    <Hash>c0d06a29c71873d937072d28d414c4f8</Hash>
</Codenesium>*/