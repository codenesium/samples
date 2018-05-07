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
		Task<CreateResponse<int>> Create(
			PipelineStepNoteModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStepNoteModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStepNote Get(int id);

		List<POCOPipelineStepNote> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c8d68ea7850263bcfe79303ed7e0710b</Hash>
</Codenesium>*/