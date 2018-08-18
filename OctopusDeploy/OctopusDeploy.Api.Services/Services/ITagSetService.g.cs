using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface ITagSetService
	{
		Task<CreateResponse<ApiTagSetResponseModel>> Create(
			ApiTagSetRequestModel model);

		Task<UpdateResponse<ApiTagSetResponseModel>> Update(string id,
		                                                     ApiTagSetRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiTagSetResponseModel> Get(string id);

		Task<List<ApiTagSetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiTagSetResponseModel> ByName(string name);

		Task<List<ApiTagSetResponseModel>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>30f353b71007743f4f3059d31ea301b6</Hash>
</Codenesium>*/