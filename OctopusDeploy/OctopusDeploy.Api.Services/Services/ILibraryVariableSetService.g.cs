using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface ILibraryVariableSetService
	{
		Task<CreateResponse<ApiLibraryVariableSetResponseModel>> Create(
			ApiLibraryVariableSetRequestModel model);

		Task<UpdateResponse<ApiLibraryVariableSetResponseModel>> Update(string id,
		                                                                 ApiLibraryVariableSetRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiLibraryVariableSetResponseModel> Get(string id);

		Task<List<ApiLibraryVariableSetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiLibraryVariableSetResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>641412761ebd6684c1185950f448e617</Hash>
</Codenesium>*/