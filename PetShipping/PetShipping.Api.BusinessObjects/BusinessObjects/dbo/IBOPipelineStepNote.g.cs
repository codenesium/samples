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

		ApiResponse GetById(int id);

		POCOPipelineStepNote GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipelineStepNote> GetWhereDirect(Expression<Func<EFPipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3eb580f23bb086851c5df4bfe669c08a</Hash>
</Codenesium>*/