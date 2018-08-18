using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface ITagsRepository
	{
		Task<Tags> Create(Tags item);

		Task Update(Tags item);

		Task Delete(int id);

		Task<Tags> Get(int id);

		Task<List<Tags>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>293aa5f771b59c6b7c636567d429e2a4</Hash>
</Codenesium>*/