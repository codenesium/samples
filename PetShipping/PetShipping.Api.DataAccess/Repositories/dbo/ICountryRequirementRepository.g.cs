using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ICountryRequirementRepository
	{
		POCOCountryRequirement Create(ApiCountryRequirementModel model);

		void Update(int id,
		            ApiCountryRequirementModel model);

		void Delete(int id);

		POCOCountryRequirement Get(int id);

		List<POCOCountryRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>30a7603eab5c8c38db334440da6e368e</Hash>
</Codenesium>*/