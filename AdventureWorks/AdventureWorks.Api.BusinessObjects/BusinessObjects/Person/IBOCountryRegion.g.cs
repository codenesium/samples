using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCountryRegion
	{
		Task<CreateResponse<string>> Create(
			CountryRegionModel model);

		Task<ActionResponse> Update(string countryRegionCode,
		                            CountryRegionModel model);

		Task<ActionResponse> Delete(string countryRegionCode);

		ApiResponse GetById(string countryRegionCode);

		POCOCountryRegion GetByIdDirect(string countryRegionCode);

		ApiResponse GetWhere(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCountryRegion> GetWhereDirect(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cd6e75a0c2298f6f115912052ce85b63</Hash>
</Codenesium>*/