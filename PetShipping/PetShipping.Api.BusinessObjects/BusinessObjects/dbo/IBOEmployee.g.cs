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
    <Hash>2906c8762cd758a0bfa2286ce7e2fcd1</Hash>
</Codenesium>*/