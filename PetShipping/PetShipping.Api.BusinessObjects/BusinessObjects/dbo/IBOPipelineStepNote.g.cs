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
			PipelineStepNoteModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStepNoteModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStepNote Get(int id);

		List<POCOPipelineStepNote> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b8e88c5c039fb7cb05c7f662bdbfab16</Hash>
</Codenesium>*/