using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOBreed
	{
		Task<CreateResponse<int>> Create(
			BreedModel model);

		Task<ActionResponse> Update(int id,
		                            BreedModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOBreed GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFBreed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBreed> GetWhereDirect(Expression<Func<EFBreed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a91c185b6f2ad4a078b7d31b970f22cb</Hash>
</Codenesium>*/