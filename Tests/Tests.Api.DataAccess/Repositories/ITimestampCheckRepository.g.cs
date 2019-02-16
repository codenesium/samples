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

		Task<List<TimestampCheck>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>a52a195c55a55b36fb00705d597bcac8</Hash>
</Codenesium>*/