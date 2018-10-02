using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IColumnSameAsFKTableService
	{
		Task<CreateResponse<ApiColumnSameAsFKTableResponseModel>> Create(
			ApiColumnSameAsFKTableRequestModel model);

		Task<UpdateResponse<ApiColumnSameAsFKTableResponseModel>> Update(int id,
		                                                                  ApiColumnSameAsFKTableRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiColumnSameAsFKTableResponseModel> Get(int id);

		Task<List<ApiColumnSameAsFKTableResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9692f17272db900a832ad2047dce689b</Hash>
</Codenesium>*/