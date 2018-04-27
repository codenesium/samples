using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOCountry
	{
		Task<CreateResponse<int>> Create(
			CountryModel model);

		Task<ActionResponse> Update(int id,
		                            CountryModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOCountry GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFCountry, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCountry> GetWhereDirect(Expression<Func<EFCountry, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c954354a77cab9a6255d91e5abb5a9a4</Hash>
</Codenesium>*/