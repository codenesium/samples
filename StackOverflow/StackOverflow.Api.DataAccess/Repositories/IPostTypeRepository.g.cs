using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostTypeRepository
	{
		Task<PostType> Create(PostType item);

		Task Update(PostType item);

		Task Delete(int id);

		Task<PostType> Get(int id);

		Task<List<PostType>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Post>> PostsByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>34f72490e05727aac7ed32056f61b6bb</Hash>
</Codenesium>*/