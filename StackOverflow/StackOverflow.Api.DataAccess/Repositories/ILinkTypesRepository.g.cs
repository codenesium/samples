using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface ILinkTypesRepository
	{
		Task<LinkTypes> Create(LinkTypes item);

		Task Update(LinkTypes item);

		Task Delete(int id);

		Task<LinkTypes> Get(int id);

		Task<List<LinkTypes>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<PostLinks>> PostLinksByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6130189a8eefd3d134e32d4ad91326ed</Hash>
</Codenesium>*/