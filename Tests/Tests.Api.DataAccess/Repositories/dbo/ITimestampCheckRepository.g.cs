using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface ITimestampCheckRepository
	{
		Task<TimestampCheck> Create(TimestampCheck item);

		Task Update(TimestampCheck item);

		Task Delete(int id);

		Task<TimestampCheck> Get(int id);

		Task<List<TimestampCheck>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f833d6525fc33f9b67c4c78f297bd829</Hash>
</Codenesium>*/