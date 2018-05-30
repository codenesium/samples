using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStepNote
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
    <Hash>bed48e5a6e7c2de0ea7eb934488f10e4</Hash>
</Codenesium>*/