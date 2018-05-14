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
		Task<CreateResponse<POCOEmployee>> Create(
			ApiEmployeeModel model);

		Task<ActionResponse> Update(int id,
		                            ApiEmployeeModel model);

		Task<ActionResponse> Delete(int id);

		POCOEmployee Get(int id);

		List<POCOEmployee> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>013951dcf7507bfa01a6b73e28b9fcd3</Hash>
</Codenesium>*/