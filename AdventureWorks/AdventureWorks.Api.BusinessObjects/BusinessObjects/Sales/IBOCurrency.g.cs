using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCurrency
	{
		Task<CreateResponse<ApiCurrencyResponseModel>> Create(
			ApiCurrencyRequestModel model);

		Task<ActionResponse> Update(string currencyCode,
		                            ApiCurrencyRequestModel model);

		Task<ActionResponse> Delete(string currencyCode);

		Task<ApiCurrencyResponseModel> Get(string currencyCode);

		Task<List<ApiCurrencyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiCurrencyResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>216c81b0a6dec4ccd85264d428334cb0</Hash>
</Codenesium>*/