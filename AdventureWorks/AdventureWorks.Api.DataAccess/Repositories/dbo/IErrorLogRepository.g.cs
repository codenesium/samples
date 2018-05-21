using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IErrorLogRepository
	{
		Task<POCOErrorLog> Create(ApiErrorLogModel model);

		Task Update(int errorLogID,
		            ApiErrorLogModel model);

		Task Delete(int errorLogID);

		Task<POCOErrorLog> Get(int errorLogID);

		Task<List<POCOErrorLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>475d8363c29973a40be6cd2d2d65191c</Hash>
</Codenesium>*/