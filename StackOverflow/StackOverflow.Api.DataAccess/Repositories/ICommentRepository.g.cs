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

		Task<List<Comment>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>aa6095ca6f73952828953a857dcd3966</Hash>
</Codenesium>*/