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
	}
}

/*<Codenesium>
    <Hash>d896bbc26c8188a089717ad220674f93</Hash>
</Codenesium>*/