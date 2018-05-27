using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IErrorLogRepository
	{
		Task<DTOErrorLog> Create(DTOErrorLog dto);

		Task Update(int errorLogID,
		            DTOErrorLog dto);

		Task Delete(int errorLogID);

		Task<DTOErrorLog> Get(int errorLogID);

		Task<List<DTOErrorLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>55c63e3425e0db3d0cc815aba88c0b84</Hash>
</Codenesium>*/