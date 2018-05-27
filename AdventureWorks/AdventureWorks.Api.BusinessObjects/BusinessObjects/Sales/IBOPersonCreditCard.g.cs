using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPersonCreditCard
	{
		Task<CreateResponse<ApiPersonCreditCardResponseModel>> Create(
			ApiPersonCreditCardRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiPersonCreditCardRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiPersonCreditCardResponseModel> Get(int businessEntityID);

		Task<List<ApiPersonCreditCardResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7fa7da2861c48d824d3c5c561006f22f</Hash>
</Codenesium>*/