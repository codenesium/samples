using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOClient
	{
		Task<CreateResponse<int>> Create(
			ClientModel model);

		Task<ActionResponse> Update(int id,
		                            ClientModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOClient GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFClient, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOClient> GetWhereDirect(Expression<Func<EFClient, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c667924bd18a68ee887b2a5a69631ad1</Hash>
</Codenesium>*/