using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOSpecies
	{
		Task<CreateResponse<int>> Create(
			SpeciesModel model);

		Task<ActionResponse> Update(int id,
		                            SpeciesModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOSpecies GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFSpecies, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpecies> GetWhereDirect(Expression<Func<EFSpecies, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b3b71839dfa717ba88644b2e0c638b67</Hash>
</Codenesium>*/