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
    <Hash>f545700da94d98af01c7688f276efa84</Hash>
</Codenesium>*/