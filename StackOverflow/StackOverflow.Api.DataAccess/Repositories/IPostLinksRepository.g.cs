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
    <Hash>d5a3d43eef319c23f47029e6011737d8</Hash>
</Codenesium>*/