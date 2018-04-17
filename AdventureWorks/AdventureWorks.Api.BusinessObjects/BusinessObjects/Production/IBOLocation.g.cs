using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLocation
	{
		Task<CreateResponse<short>> Create(
			LocationModel model);

		Task<ActionResponse> Update(short locationID,
		                            LocationModel model);

		Task<ActionResponse> Delete(short locationID);

		ApiResponse GetById(short locationID);

		POCOLocation GetByIdDirect(short locationID);

		ApiResponse GetWhere(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLocation> GetWhereDirect(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4532dcb20f406a655d93ec4c9bc04c13</Hash>
</Codenesium>*/