using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ICountryRequirementRepository
	{
		POCOCountryRequirement Create(CountryRequirementModel model);

		void Update(int id,
		            CountryRequirementModel model);

		void Delete(int id);

		POCOCountryRequirement Get(int id);

		List<POCOCountryRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ce31f958978ee6c3ac4248496eb8d37e</Hash>
</Codenesium>*/