using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOEmployee
	{
		Task<CreateResponse<int>> Create(
			EmployeeModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            EmployeeModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOEmployee Get(int businessEntityID);

		List<POCOEmployee> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>31085de7073af51c74cf8ee31c0ca9ae</Hash>
</Codenesium>*/