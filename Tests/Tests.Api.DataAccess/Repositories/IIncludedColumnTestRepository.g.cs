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

		Task<List<IncludedColumnTest>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0135ad1c2c61db20be8734b1b01e316b</Hash>
</Codenesium>*/