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

		Task<List<PostHistoryTypes>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<PostHistory>> PostHistoryByPostHistoryTypeId(int postHistoryTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d0accfdf2ed12e5790e364784fb374b3</Hash>
</Codenesium>*/