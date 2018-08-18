using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IPersonRefService
	{
		Task<CreateResponse<ApiPersonRefResponseModel>> Create(
			ApiPersonRefRequestModel model);

		Task<UpdateResponse<ApiPersonRefResponseModel>> Update(int id,
		                                                        ApiPersonRefRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPersonRefResponseModel> Get(int id);

		Task<List<ApiPersonRefResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7b05b67a5ec51785abb5e3ce295f1900</Hash>
</Codenesium>*/