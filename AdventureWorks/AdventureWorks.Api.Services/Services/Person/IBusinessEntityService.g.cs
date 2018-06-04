using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IBusinessEntityService
	{
		Task<CreateResponse<ApiBusinessEntityResponseModel>> Create(
			ApiBusinessEntityRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiBusinessEntityRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiBusinessEntityResponseModel> Get(int businessEntityID);

		Task<List<ApiBusinessEntityResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>51dcec9f84acecf7d07cb8afe2537940</Hash>
</Codenesium>*/