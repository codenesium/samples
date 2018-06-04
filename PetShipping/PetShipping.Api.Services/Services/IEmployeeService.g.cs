using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IEmployeeService
	{
		Task<CreateResponse<ApiEmployeeResponseModel>> Create(
			ApiEmployeeRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiEmployeeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEmployeeResponseModel> Get(int id);

		Task<List<ApiEmployeeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>abe0016c6a3a63a1dd7a44997132ca6d</Hash>
</Codenesium>*/