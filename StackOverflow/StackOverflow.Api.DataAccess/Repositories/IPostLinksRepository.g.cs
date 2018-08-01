using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public interface IPostLinksRepository
	{
		Task<PostLinks> Create(PostLinks item);

		Task Update(PostLinks item);

		Task Delete(int id);

		Task<PostLinks> Get(int id);

		Task<List<PostLinks>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>91b2e12e7c987b356b937eff42595cf1</Hash>
</Codenesium>*/