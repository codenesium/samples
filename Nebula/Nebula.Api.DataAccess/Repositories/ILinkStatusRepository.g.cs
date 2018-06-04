using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkStatusRepository
	{
		Task<LinkStatus> Create(LinkStatus item);

		Task Update(LinkStatus item);

		Task Delete(int id);

		Task<LinkStatus> Get(int id);

		Task<List<LinkStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d0b80b61ccfcf2ba7daf4e771812e7e4</Hash>
</Codenesium>*/