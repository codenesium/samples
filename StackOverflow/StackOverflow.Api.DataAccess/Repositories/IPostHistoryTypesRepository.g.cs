using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostHistoryTypesRepository
	{
		Task<PostHistoryTypes> Create(PostHistoryTypes item);

		Task Update(PostHistoryTypes item);

		Task Delete(int id);

		Task<PostHistoryTypes> Get(int id);

		Task<List<PostHistoryTypes>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d3253e774c26a380652bf4c235db22f3</Hash>
</Codenesium>*/