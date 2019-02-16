using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface ILinkLogRepository
	{
		Task<LinkLog> Create(LinkLog item);

		Task Update(LinkLog item);

		Task Delete(int id);

		Task<LinkLog> Get(int id);

		Task<List<LinkLog>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Link> LinkByLinkId(int linkId);
	}
}

/*<Codenesium>
    <Hash>592d25ac30dbb1af8bed38d61685632c</Hash>
</Codenesium>*/