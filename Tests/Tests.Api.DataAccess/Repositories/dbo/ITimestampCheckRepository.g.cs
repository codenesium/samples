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
    <Hash>3388e9b4739b1c8ea0c9e7c1985567cc</Hash>
</Codenesium>*/