using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public interface ITimestampCheckRepository
	{
		Task<TimestampCheck> Create(TimestampCheck item);

		Task Update(TimestampCheck item);

		Task Delete(int id);

		Task<TimestampCheck> Get(int id);

		Task<List<TimestampCheck>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>142c39a129e9662a976c50aaebe86b19</Hash>
</Codenesium>*/