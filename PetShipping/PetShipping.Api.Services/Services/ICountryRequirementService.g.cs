using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface ICountryRequirementService
	{
		Task<CreateResponse<ApiCountryRequirementServerResponseModel>> Create(
			ApiCountryRequirementServerRequestModel model);

		Task<UpdateResponse<ApiCountryRequirementServerResponseModel>> Update(int id,
		                                                                       ApiCountryRequirementServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCountryRequirementServerResponseModel> Get(int id);

		Task<List<ApiCountryRequirementServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5464e940efad002c2f42ca23d9277b9a</Hash>
</Codenesium>*/