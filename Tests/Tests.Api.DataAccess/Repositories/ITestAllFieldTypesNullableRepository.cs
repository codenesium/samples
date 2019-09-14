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

		Task<List<TestAllFieldTypesNullable>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>6b926554dd6d339435800374ee919579</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/