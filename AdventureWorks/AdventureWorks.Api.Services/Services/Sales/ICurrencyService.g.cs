using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ICurrencyService
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
    <Hash>603eb934d87106ba84ebe4779cba6e29</Hash>
</Codenesium>*/