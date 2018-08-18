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
    <Hash>6f14bd5affea216603c457123c5ef4f6</Hash>
</Codenesium>*/