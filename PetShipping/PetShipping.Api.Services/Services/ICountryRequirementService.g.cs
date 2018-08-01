using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface ICountryRequirementService
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
    <Hash>f06845951c117cec271a50e37c8c5856</Hash>
</Codenesium>*/