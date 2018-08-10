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

		Task<List<ErrorLog>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b9a2e2e10ab2be6ab9f0cd18d891b37c</Hash>
</Codenesium>*/