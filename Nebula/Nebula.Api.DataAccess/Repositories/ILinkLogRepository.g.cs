using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkLogRepository
	{
		Task<LinkLog> Create(LinkLog item);

		Task Update(LinkLog item);

		Task Delete(int id);

		Task<LinkLog> Get(int id);

		Task<List<LinkLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0d07a9841d97076c6b238f51a3f29a52</Hash>
</Codenesium>*/