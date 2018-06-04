using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkRepository
	{
		Task<Link> Create(Link item);

		Task Update(Link item);

		Task Delete(int id);

		Task<Link> Get(int id);

		Task<List<Link>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d4d9d6434049f896d4bdacf1155c9bf1</Hash>
</Codenesium>*/