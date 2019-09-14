using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface ITestAllFieldTypeRepository
	{
		Task<TestAllFieldType> Create(TestAllFieldType item);

		Task Update(TestAllFieldType item);

		Task Delete(int id);

		Task<TestAllFieldType> Get(int id);

		Task<List<TestAllFieldType>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>2c215ac1af2717826193498fee21ef65</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/