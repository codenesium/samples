using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOChainStatus
	{
		Task<CreateResponse<ApiChainStatusResponseModel>> Create(
			ApiChainStatusRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiChainStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiChainStatusResponseModel> Get(int id);

		Task<List<ApiChainStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiChainStatusResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>76ebc56e7e339fafd01c3970dbc5779e</Hash>
</Codenesium>*/