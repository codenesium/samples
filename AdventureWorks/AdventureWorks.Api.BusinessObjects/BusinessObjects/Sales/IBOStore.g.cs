using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOStore
	{
		Task<CreateResponse<int>> Create(
			StoreModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            StoreModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOStore GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFStore, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStore> GetWhereDirect(Expression<Func<EFStore, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>792281ff2776d49f0ccbc0e8efac1b29</Hash>
</Codenesium>*/