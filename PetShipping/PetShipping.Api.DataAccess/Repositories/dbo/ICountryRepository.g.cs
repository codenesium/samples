using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ICountryRepository
	{
		int Create(CountryModel model);

		void Update(int id,
		            CountryModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOCountry GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFCountry, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCountry> GetWhereDirect(Expression<Func<EFCountry, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5445fbe15ab27d78e6fe9f211be8653d</Hash>
</Codenesium>*/