using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface ICommentRepository
	{
		Task<Comment> Create(Comment item);

		Task Update(Comment item);

		Task Delete(int id);

		Task<Comment> Get(int id);

		Task<List<Comment>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>c3b7173b24b951400d3738e419603270</Hash>
</Codenesium>*/