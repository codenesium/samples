using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IProjectService
	{
		Task<CreateResponse<ApiProjectResponseModel>> Create(
			ApiProjectRequestModel model);

		Task<UpdateResponse<ApiProjectResponseModel>> Update(string id,
		                                                      ApiProjectRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiProjectResponseModel> Get(string id);

		Task<List<ApiProjectResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProjectResponseModel> ByName(string name);

		Task<ApiProjectResponseModel> BySlug(string slug);

		Task<List<ApiProjectResponseModel>> ByDataVersion(byte[] dataVersion);

		Task<List<ApiProjectResponseModel>> ByDiscreteChannelReleaseId(bool discreteChannelRelease, string id);
	}
}

/*<Codenesium>
    <Hash>8ca09410c4cc3535d1ddc199bc64e4aa</Hash>
</Codenesium>*/