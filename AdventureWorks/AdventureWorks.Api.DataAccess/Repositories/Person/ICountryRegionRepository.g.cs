using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionRepository
	{
		string Create(
			string name,
			DateTime modifiedDate);

		void Update(string countryRegionCode,
		            string name,
		            DateTime modifiedDate);

		void Delete(string countryRegionCode);

		Response GetById(string countryRegionCode);

		POCOCountryRegion GetByIdDirect(string countryRegionCode);

		Response GetWhere(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCountryRegion> GetWhereDirect(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c0c8d2f38e94f94123c8cda2a0b0e6a3</Hash>
</Codenesium>*/