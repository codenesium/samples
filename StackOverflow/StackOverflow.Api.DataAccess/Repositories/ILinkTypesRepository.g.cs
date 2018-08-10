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

		Task<List<LinkTypes>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9e33c99dce026644b723da985ae2222b</Hash>
</Codenesium>*/