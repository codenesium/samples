using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionRepository
	{
		string Create(string name,
		              DateTime modifiedDate);

		void Update(string countryRegionCode, string name,
		            DateTime modifiedDate);

		void Delete(string countryRegionCode);

		void GetById(string countryRegionCode, Response response);

		void GetWhere(Expression<Func<EFCountryRegion, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8b7da46222a3b9f4bdaafd0b407a2977</Hash>
</Codenesium>*/