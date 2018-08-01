using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public interface ITestAllFieldTypeRepository
	{
		Task<TestAllFieldType> Create(TestAllFieldType item);

		Task Update(TestAllFieldType item);

		Task Delete(int id);

		Task<TestAllFieldType> Get(int id);

		Task<List<TestAllFieldType>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>00405703c55c646d7d39c3621e3ff6a8</Hash>
</Codenesium>*/