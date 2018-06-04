using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeePayHistoryRepository
	{
		Task<EmployeePayHistory> Create(EmployeePayHistory item);

		Task Update(EmployeePayHistory item);

		Task Delete(int businessEntityID);

		Task<EmployeePayHistory> Get(int businessEntityID);

		Task<List<EmployeePayHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2174158f59af793d3b9576888427d95a</Hash>
</Codenesium>*/