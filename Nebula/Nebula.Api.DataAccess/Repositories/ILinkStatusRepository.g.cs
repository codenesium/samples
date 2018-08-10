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

		Task<List<Link>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>88f1dd33ff435ffc4863a2770b0e5dbf</Hash>
</Codenesium>*/