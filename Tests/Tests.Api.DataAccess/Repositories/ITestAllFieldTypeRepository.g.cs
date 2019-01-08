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
    <Hash>9e0e36aef3b66d821f0237ce375a179d</Hash>
</Codenesium>*/