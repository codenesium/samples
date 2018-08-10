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
    <Hash>ba72ca0b3bfa61b1f5fdbab9a4d4be93</Hash>
</Codenesium>*/