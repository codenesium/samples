using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOCountryRequirement
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
    <Hash>ef6d3c8bda17794f5d71de1c3749e1a6</Hash>
</Codenesium>*/