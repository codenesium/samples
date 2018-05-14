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
		Task<CreateResponse<POCOErrorLog>> Create(
			ApiErrorLogModel model);

		Task<ActionResponse> Update(int errorLogID,
		                            ApiErrorLogModel model);

		Task<ActionResponse> Delete(int errorLogID);

		POCOErrorLog Get(int errorLogID);

		List<POCOErrorLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>93fd9e213467928881d51e478be70025</Hash>
</Codenesium>*/