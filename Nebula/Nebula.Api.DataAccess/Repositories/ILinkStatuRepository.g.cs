using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface ILinkStatuRepository
	{
		Task<LinkStatu> Create(LinkStatu item);

		Task Update(LinkStatu item);

		Task Delete(int id);

		Task<LinkStatu> Get(int id);

		Task<List<LinkStatu>> All(int limit = int.MaxValue, int offset = 0);

		Task<LinkStatu> ByName(string name);

		Task<List<Link>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>095ca7cfd2d95398d3e6e4b70782b2b3</Hash>
</Codenesium>*/