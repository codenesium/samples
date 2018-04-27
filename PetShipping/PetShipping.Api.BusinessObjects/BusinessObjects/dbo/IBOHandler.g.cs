using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOHandler
	{
		Task<CreateResponse<int>> Create(
			HandlerModel model);

		Task<ActionResponse> Update(int id,
		                            HandlerModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOHandler GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFHandler, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOHandler> GetWhereDirect(Expression<Func<EFHandler, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>45973e2c4b2e39a76fa19b655e539b2c</Hash>
</Codenesium>*/