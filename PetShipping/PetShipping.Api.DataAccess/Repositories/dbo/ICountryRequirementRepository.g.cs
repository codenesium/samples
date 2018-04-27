using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ICountryRequirementRepository
	{
		int Create(CountryRequirementModel model);

		void Update(int id,
		            CountryRequirementModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOCountryRequirement GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFCountryRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCountryRequirement> GetWhereDirect(Expression<Func<EFCountryRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a1992e4e8a6dd35c40c9bab108e385b4</Hash>
</Codenesium>*/