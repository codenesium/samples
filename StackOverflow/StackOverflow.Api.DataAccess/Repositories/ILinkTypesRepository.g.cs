using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public interface ILinkTypesRepository
	{
		Task<LinkTypes> Create(LinkTypes item);

		Task Update(LinkTypes item);

		Task Delete(int id);

		Task<LinkTypes> Get(int id);

		Task<List<LinkTypes>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>dd4d31394f3799257d01fde0d2d5c65a</Hash>
</Codenesium>*/