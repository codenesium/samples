using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface ICountryRequirementService
	{
		Task<CreateResponse<ApiCountryRequirementResponseModel>> Create(
			ApiCountryRequirementRequestModel model);

		Task<UpdateResponse<ApiCountryRequirementResponseModel>> Update(int id,
		                                                                 ApiCountryRequirementRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCountryRequirementResponseModel> Get(int id);

		Task<List<ApiCountryRequirementResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0ed70fb7db1ab743db0e7083b6aa05b9</Hash>
</Codenesium>*/