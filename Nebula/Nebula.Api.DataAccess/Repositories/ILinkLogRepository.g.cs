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

		Task<List<LinkLog>> All(int limit = int.MaxValue, int offset = 0);

		Task<Link> LinkByLinkId(int linkId);
	}
}

/*<Codenesium>
    <Hash>a4ba2396398ed4ab0f7b4ce052d2fa21</Hash>
</Codenesium>*/