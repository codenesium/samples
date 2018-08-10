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

		Task<List<TestAllFieldType>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>682e3455ca901346877456560849148c</Hash>
</Codenesium>*/