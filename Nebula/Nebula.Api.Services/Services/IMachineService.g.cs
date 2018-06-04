using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public interface IMachineService
	{
		Task<CreateResponse<ApiMachineResponseModel>> Create(
			ApiMachineRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiMachineRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiMachineResponseModel> Get(int id);

		Task<List<ApiMachineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>770e4fe49738fae64d051b89e71f063e</Hash>
</Codenesium>*/