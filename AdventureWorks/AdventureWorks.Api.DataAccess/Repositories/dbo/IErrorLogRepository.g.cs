using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IErrorLogRepository
	{
		Task<ErrorLog> Create(ErrorLog item);

		Task Update(ErrorLog item);

		Task Delete(int errorLogID);

		Task<ErrorLog> Get(int errorLogID);

		Task<List<ErrorLog>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>17d7de1ae6c1d742d532d8a76e4cc1df</Hash>
</Codenesium>*/