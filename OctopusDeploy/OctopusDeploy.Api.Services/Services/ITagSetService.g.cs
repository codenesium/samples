using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface ITagSetService
	{
		Task<CreateResponse<ApiTagSetResponseModel>> Create(
			ApiTagSetRequestModel model);

		Task<UpdateResponse<ApiTagSetResponseModel>> Update(string id,
		                                                     ApiTagSetRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiTagSetResponseModel> Get(string id);

		Task<List<ApiTagSetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiTagSetResponseModel> ByName(string name);

		Task<List<ApiTagSetResponseModel>> ByDataVersion(byte[] dataVersion);
	}
}

/*<Codenesium>
    <Hash>e76598fff24a47eaf04c19ab3f1f0343</Hash>
</Codenesium>*/