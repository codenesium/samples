using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IPipelineStepStatusService
	{
		Task<CreateResponse<ApiPipelineStepStatusResponseModel>> Create(
			ApiPipelineStepStatusRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStepStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepStatusResponseModel> Get(int id);

		Task<List<ApiPipelineStepStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cfd408cbef6422d727c2ae4f7fb13d92</Hash>
</Codenesium>*/