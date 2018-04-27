using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOAirline
	{
		Task<CreateResponse<int>> Create(
			AirlineModel model);

		Task<ActionResponse> Update(int id,
		                            AirlineModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOAirline GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFAirline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAirline> GetWhereDirect(Expression<Func<EFAirline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1b31151b561586f110977781188d60f3</Hash>
</Codenesium>*/