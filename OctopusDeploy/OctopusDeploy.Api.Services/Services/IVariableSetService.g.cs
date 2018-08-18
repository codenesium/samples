using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IVariableSetService
	{
		Task<CreateResponse<ApiVariableSetResponseModel>> Create(
			ApiVariableSetRequestModel model);

		Task<UpdateResponse<ApiVariableSetResponseModel>> Update(string id,
		                                                          ApiVariableSetRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiVariableSetResponseModel> Get(string id);

		Task<List<ApiVariableSetResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b975a5aa80b162236c2c191acf4752e3</Hash>
</Codenesium>*/