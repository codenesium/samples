using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostLinksRepository
	{
		Task<PostLinks> Create(PostLinks item);

		Task Update(PostLinks item);

		Task Delete(int id);

		Task<PostLinks> Get(int id);

		Task<List<PostLinks>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>63d4d69bde4b468426ea6d27cd7f76ca</Hash>
</Codenesium>*/