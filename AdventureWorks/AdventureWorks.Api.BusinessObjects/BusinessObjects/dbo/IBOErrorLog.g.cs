using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOErrorLog
	{
		Task<CreateResponse<int>> Create(
			ErrorLogModel model);

		Task<ActionResponse> Update(int errorLogID,
		                            ErrorLogModel model);

		Task<ActionResponse> Delete(int errorLogID);

		POCOErrorLog Get(int errorLogID);

		List<POCOErrorLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2a97f8bfe950bf14c7934226a3ddeeed</Hash>
</Codenesium>*/