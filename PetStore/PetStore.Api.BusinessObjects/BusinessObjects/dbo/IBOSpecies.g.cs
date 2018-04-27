using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
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
    <Hash>22c76c91a02f3a87e7e72eb1166c0e4c</Hash>
</Codenesium>*/