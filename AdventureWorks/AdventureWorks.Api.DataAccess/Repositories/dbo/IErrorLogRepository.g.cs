using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IErrorLogRepository
	{
		Task<ErrorLog> Create(ErrorLog item);

		Task Update(ErrorLog item);

		Task Delete(int errorLogID);

		Task<ErrorLog> Get(int errorLogID);

		Task<List<ErrorLog>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>d73fc27e481f53472467a397be166d2a</Hash>
</Codenesium>*/