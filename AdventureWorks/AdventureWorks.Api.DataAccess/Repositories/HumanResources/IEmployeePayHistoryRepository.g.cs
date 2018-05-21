using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeePayHistoryRepository
	{
		Task<POCOEmployeePayHistory> Create(ApiEmployeePayHistoryModel model);

		Task Update(int businessEntityID,
		            ApiEmployeePayHistoryModel model);

		Task Delete(int businessEntityID);

		Task<POCOEmployeePayHistory> Get(int businessEntityID);

		Task<List<POCOEmployeePayHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2480ef093c634320d2c2b13814d94c24</Hash>
</Codenesium>*/