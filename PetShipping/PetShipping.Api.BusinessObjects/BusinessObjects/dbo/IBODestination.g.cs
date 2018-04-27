using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBODestination
	{
		Task<CreateResponse<int>> Create(
			DestinationModel model);

		Task<ActionResponse> Update(int id,
		                            DestinationModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCODestination GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODestination> GetWhereDirect(Expression<Func<EFDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2d7952d6597b155365896fbfb9cc291c</Hash>
</Codenesium>*/