using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface IIncludedColumnTestRepository
	{
		Task<IncludedColumnTest> Create(IncludedColumnTest item);

		Task Update(IncludedColumnTest item);

		Task Delete(int id);

		Task<IncludedColumnTest> Get(int id);

		Task<List<IncludedColumnTest>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>1e4389fdb3e20e3423dddf8511bde8fa</Hash>
</Codenesium>*/