using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public interface IPostHistoryTypesRepository
	{
		Task<PostHistoryTypes> Create(PostHistoryTypes item);

		Task Update(PostHistoryTypes item);

		Task Delete(int id);

		Task<PostHistoryTypes> Get(int id);

		Task<List<PostHistoryTypes>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6f31603601346105050b59f5f2e3f2ae</Hash>
</Codenesium>*/