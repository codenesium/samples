using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipeline
	{
		Task<CreateResponse<ApiPipelineResponseModel>> Create(
			ApiPipelineRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineResponseModel> Get(int id);

		Task<List<ApiPipelineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d9b89bfc764f6a0968dea5a69ca63db3</Hash>
</Codenesium>*/