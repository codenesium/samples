using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCountryRegionCurrency
	{
		Task<CreateResponse<string>> Create(
			CountryRegionCurrencyModel model);

		Task<ActionResponse> Update(string countryRegionCode,
		                            CountryRegionCurrencyModel model);

		Task<ActionResponse> Delete(string countryRegionCode);

		ApiResponse GetById(string countryRegionCode);

		POCOCountryRegionCurrency GetByIdDirect(string countryRegionCode);

		ApiResponse GetWhere(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCountryRegionCurrency> GetWhereDirect(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>81a47094a3c888af46c93472a77852c8</Hash>
</Codenesium>*/