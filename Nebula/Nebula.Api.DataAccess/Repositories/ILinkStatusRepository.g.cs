using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface ILinkStatusRepository
	{
		Task<LinkStatus> Create(LinkStatus item);

		Task Update(LinkStatus item);

		Task Delete(int id);

		Task<LinkStatus> Get(int id);

		Task<List<LinkStatus>> All(int limit = int.MaxValue, int offset = 0);

		Task<LinkStatus> ByName(string name);

		Task<List<Link>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>950312acec31d013668c054e6aff6acd</Hash>
</Codenesium>*/