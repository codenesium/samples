using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public interface ITestAllFieldTypesNullableRepository
	{
		Task<TestAllFieldTypesNullable> Create(TestAllFieldTypesNullable item);

		Task Update(TestAllFieldTypesNullable item);

		Task Delete(int id);

		Task<TestAllFieldTypesNullable> Get(int id);

		Task<List<TestAllFieldTypesNullable>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3649b0f866c66608d87274801436c63e</Hash>
</Codenesium>*/