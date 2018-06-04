using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IPipelineStepNoteService
	{
		Task<CreateResponse<ApiPipelineStepNoteResponseModel>> Create(
			ApiPipelineStepNoteRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStepNoteRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepNoteResponseModel> Get(int id);

		Task<List<ApiPipelineStepNoteResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1ab77f8f0291dc253fa93d7ce78ee61a</Hash>
</Codenesium>*/