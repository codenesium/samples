using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
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
    <Hash>50d54d760100c13a497b8a616783387b</Hash>
</Codenesium>*/