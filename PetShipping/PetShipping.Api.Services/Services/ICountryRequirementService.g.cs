using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface ICountryRequirementService
	{
		Task<CreateResponse<ApiCountryRequirementResponseModel>> Create(
			ApiCountryRequirementRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiCountryRequirementRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCountryRequirementResponseModel> Get(int id);

		Task<List<ApiCountryRequirementResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dac981176086f53696d6096977a986b7</Hash>
</Codenesium>*/