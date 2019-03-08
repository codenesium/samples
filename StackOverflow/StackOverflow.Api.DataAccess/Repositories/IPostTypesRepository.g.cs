using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostTypesRepository
	{
		Task<PostTypes> Create(PostTypes item);

		Task Update(PostTypes item);

		Task Delete(int id);

		Task<PostTypes> Get(int id);

		Task<List<PostTypes>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Posts>> PostsByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>befaf445a4497ea3d31fd44d21d90e35</Hash>
</Codenesium>*/