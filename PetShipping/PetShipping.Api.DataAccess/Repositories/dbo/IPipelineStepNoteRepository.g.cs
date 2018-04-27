using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepNoteRepository
	{
		int Create(PipelineStepNoteModel model);

		void Update(int id,
		            PipelineStepNoteModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOPipelineStepNote GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipelineStepNote> GetWhereDirect(Expression<Func<EFPipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a3c34309fa457e17624143cec60c9e02</Hash>
</Codenesium>*/