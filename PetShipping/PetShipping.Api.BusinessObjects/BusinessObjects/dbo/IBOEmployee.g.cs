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

		Task<POCOEmployee> Get(int id);

		Task<List<POCOEmployee>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7cd9b8bf484699068f764bb60bb7820a</Hash>
</Codenesium>*/