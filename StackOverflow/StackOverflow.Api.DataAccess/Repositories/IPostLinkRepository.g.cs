using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostLinkRepository
	{
		Task<PostLink> Create(PostLink item);

		Task Update(PostLink item);

		Task Delete(int id);

		Task<PostLink> Get(int id);

		Task<List<PostLink>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>0baf0eac9558c7abaf9c02758b41a353</Hash>
</Codenesium>*/