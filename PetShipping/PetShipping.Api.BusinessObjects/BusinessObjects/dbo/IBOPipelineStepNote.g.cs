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
		Task<CreateResponse<POCOPipelineStepNote>> Create(
			ApiPipelineStepNoteModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStepNoteModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOPipelineStepNote> Get(int id);

		Task<List<POCOPipelineStepNote>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d1651961f8a90a8f408773f3bf51ab67</Hash>
</Codenesium>*/