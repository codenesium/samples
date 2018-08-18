using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface ITestAllFieldTypesNullableRepository
	{
		Task<TestAllFieldTypesNullable> Create(TestAllFieldTypesNullable item);

		Task Update(TestAllFieldTypesNullable item);

		Task Delete(int id);

		Task<TestAllFieldTypesNullable> Get(int id);

		Task<List<TestAllFieldTypesNullable>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>818959e197112e6c6e9b5cb221d374c3</Hash>
</Codenesium>*/