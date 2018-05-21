using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkLogRepository
	{
		Task<POCOLinkLog> Create(ApiLinkLogModel model);

		Task Update(int id,
		            ApiLinkLogModel model);

		Task Delete(int id);

		Task<POCOLinkLog> Get(int id);

		Task<List<POCOLinkLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b0b67bc9358f2357d9a44e268790aa49</Hash>
</Codenesium>*/