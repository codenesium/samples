using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IErrorLogRepository
	{
		Task<ErrorLog> Create(ErrorLog item);

		Task Update(ErrorLog item);

		Task Delete(int errorLogID);

		Task<ErrorLog> Get(int errorLogID);

		Task<List<ErrorLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>efdce5903cc9822b9ab22c6f7329fd40</Hash>
</Codenesium>*/