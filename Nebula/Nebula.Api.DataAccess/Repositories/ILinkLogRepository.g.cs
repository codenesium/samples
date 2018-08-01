using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkLogRepository
	{
		Task<LinkLog> Create(LinkLog item);

		Task Update(LinkLog item);

		Task Delete(int id);

		Task<LinkLog> Get(int id);

		Task<List<LinkLog>> All(int limit = int.MaxValue, int offset = 0);

		Task<Link> GetLink(int linkId);
	}
}

/*<Codenesium>
    <Hash>d10988c9e4513d39e1f9f1791ab13ddf</Hash>
</Codenesium>*/