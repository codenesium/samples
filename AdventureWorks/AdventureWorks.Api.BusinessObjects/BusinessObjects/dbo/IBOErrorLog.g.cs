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

		Task<POCOErrorLog> Get(int errorLogID);

		Task<List<POCOErrorLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a5d69d5096e04c0db4adc6648e49ae9b</Hash>
</Codenesium>*/