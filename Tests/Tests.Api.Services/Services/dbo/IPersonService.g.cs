using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IPersonService
	{
		Task<CreateResponse<ApiPersonResponseModel>> Create(
			ApiPersonRequestModel model);

		Task<UpdateResponse<ApiPersonResponseModel>> Update(int personId,
		                                                     ApiPersonRequestModel model);

		Task<ActionResponse> Delete(int personId);

		Task<ApiPersonResponseModel> Get(int personId);

		Task<List<ApiPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiColumnSameAsFKTableResponseModel>> ColumnSameAsFKTables(int person, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>495416c34996ff9a71dd1a10fdb3e835</Hash>
</Codenesium>*/