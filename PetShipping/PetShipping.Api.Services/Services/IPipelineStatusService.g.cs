using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IPipelineStatusService
	{
		Task<CreateResponse<ApiPipelineStatusResponseModel>> Create(
			ApiPipelineStatusRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStatusResponseModel> Get(int id);

		Task<List<ApiPipelineStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5b97c1042c5fa37131fbc3f94b793d15</Hash>
</Codenesium>*/