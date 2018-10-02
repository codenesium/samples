using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ISysdiagramService
	{
		Task<CreateResponse<ApiSysdiagramResponseModel>> Create(
			ApiSysdiagramRequestModel model);

		Task<UpdateResponse<ApiSysdiagramResponseModel>> Update(int diagramId,
		                                                         ApiSysdiagramRequestModel model);

		Task<ActionResponse> Delete(int diagramId);

		Task<ApiSysdiagramResponseModel> Get(int diagramId);

		Task<List<ApiSysdiagramResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiSysdiagramResponseModel> ByPrincipalIdName(int principalId, string name);
	}
}

/*<Codenesium>
    <Hash>409a386d0890c42edfa10adb823124a2</Hash>
</Codenesium>*/