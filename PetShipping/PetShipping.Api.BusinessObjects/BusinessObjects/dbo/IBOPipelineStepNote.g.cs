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

		POCOPipelineStepNote Get(int id);

		List<POCOPipelineStepNote> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>22f1c37ef78ed3487e639384fbd966e1</Hash>
</Codenesium>*/