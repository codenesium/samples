using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOEmployee
	{
		Task<CreateResponse<int>> Create(
			EmployeeModel model);

		Task<ActionResponse> Update(int id,
		                            EmployeeModel model);

		Task<ActionResponse> Delete(int id);

		POCOEmployee Get(int id);

		List<POCOEmployee> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e05853bcb5da1d4a210fc6876d889626</Hash>
</Codenesium>*/