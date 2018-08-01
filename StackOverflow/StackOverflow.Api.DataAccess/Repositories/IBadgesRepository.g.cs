using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public interface IBadgesRepository
	{
		Task<Badges> Create(Badges item);

		Task Update(Badges item);

		Task Delete(int id);

		Task<Badges> Get(int id);

		Task<List<Badges>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7e89cbb930c0274a83429611b4e9bdf3</Hash>
</Codenesium>*/