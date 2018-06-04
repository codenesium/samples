using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public interface IPaymentTypeService
	{
		Task<CreateResponse<ApiPaymentTypeResponseModel>> Create(
			ApiPaymentTypeRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPaymentTypeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPaymentTypeResponseModel> Get(int id);

		Task<List<ApiPaymentTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>863985ee9fa36efe57cf183ec0f1b84e</Hash>
</Codenesium>*/