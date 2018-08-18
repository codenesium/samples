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

		Task<Link> GetLink(int linkId);
	}
}

/*<Codenesium>
    <Hash>a5bf44c82b3b970e5e3cc7b8800b0d78</Hash>
</Codenesium>*/