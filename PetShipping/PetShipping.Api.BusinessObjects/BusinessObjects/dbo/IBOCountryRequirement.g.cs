using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOCountryRequirement
	{
		Task<CreateResponse<int>> Create(
			CountryRequirementModel model);

		Task<ActionResponse> Update(int id,
		                            CountryRequirementModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOCountryRequirement GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFCountryRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCountryRequirement> GetWhereDirect(Expression<Func<EFCountryRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6f494ca1c68b92f3c18756e2c71656a9</Hash>
</Codenesium>*/