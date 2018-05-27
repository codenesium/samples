using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeePayHistoryRepository
	{
		Task<DTOEmployeePayHistory> Create(DTOEmployeePayHistory dto);

		Task Update(int businessEntityID,
		            DTOEmployeePayHistory dto);

		Task Delete(int businessEntityID);

		Task<DTOEmployeePayHistory> Get(int businessEntityID);

		Task<List<DTOEmployeePayHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>eb3985c6b27144b1c751be5a7413a770</Hash>
</Codenesium>*/