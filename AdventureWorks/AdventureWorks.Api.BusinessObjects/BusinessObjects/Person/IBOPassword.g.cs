using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPassword
	{
		Task<CreateResponse<ApiPasswordResponseModel>> Create(
			ApiPasswordRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiPasswordRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiPasswordResponseModel> Get(int businessEntityID);

		Task<List<ApiPasswordResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0d0dd05b615e0ebc191e0aa17e255663</Hash>
</Codenesium>*/