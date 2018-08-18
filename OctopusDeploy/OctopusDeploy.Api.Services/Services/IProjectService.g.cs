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

		Task<List<ApiProjectResponseModel>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProjectResponseModel>> ByDiscreteChannelReleaseId(bool discreteChannelRelease, string id, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8f3248ad1c3bbef49ecf2f225a7bfe7f</Hash>
</Codenesium>*/