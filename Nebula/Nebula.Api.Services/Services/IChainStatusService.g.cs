using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public interface IChainStatusService
	{
		Task<CreateResponse<ApiChainStatusResponseModel>> Create(
			ApiChainStatusRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiChainStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiChainStatusResponseModel> Get(int id);

		Task<List<ApiChainStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1758d5d43fd06134aa4f942f4e3e4786</Hash>
</Codenesium>*/