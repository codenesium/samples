using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IEmployeePayHistoryRepository
	{
		Task<EmployeePayHistory> Create(EmployeePayHistory item);

		Task Update(EmployeePayHistory item);

		Task Delete(int businessEntityID);

		Task<EmployeePayHistory> Get(int businessEntityID);

		Task<List<EmployeePayHistory>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>443f8e9c6bb7e48cfe6b226770037907</Hash>
</Codenesium>*/