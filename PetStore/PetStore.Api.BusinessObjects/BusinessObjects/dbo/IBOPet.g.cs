using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOPet
	{
		Task<CreateResponse<int>> Create(
			PetModel model);

		Task<ActionResponse> Update(int id,
		                            PetModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOPet GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPet, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPet> GetWhereDirect(Expression<Func<EFPet, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>508b4cef6bf6cb26956c0b6f4f9bb3ee</Hash>
</Codenesium>*/