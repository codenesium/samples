using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public interface ITagsRepository
	{
		Task<Tags> Create(Tags item);

		Task Update(Tags item);

		Task Delete(int id);

		Task<Tags> Get(int id);

		Task<List<Tags>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7d24567721e48050da2c494ec605face</Hash>
</Codenesium>*/