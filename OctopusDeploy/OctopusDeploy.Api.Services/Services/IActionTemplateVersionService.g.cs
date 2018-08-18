using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IActionTemplateVersionService
	{
		Task<CreateResponse<ApiActionTemplateVersionResponseModel>> Create(
			ApiActionTemplateVersionRequestModel model);

		Task<UpdateResponse<ApiActionTemplateVersionResponseModel>> Update(string id,
		                                                                    ApiActionTemplateVersionRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiActionTemplateVersionResponseModel> Get(string id);

		Task<List<ApiActionTemplateVersionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiActionTemplateVersionResponseModel> ByNameVersion(string name, int version);

		Task<List<ApiActionTemplateVersionResponseModel>> ByLatestActionTemplateId(string latestActionTemplateId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>cdf2dad231beb70251b643b631f993d8</Hash>
</Codenesium>*/