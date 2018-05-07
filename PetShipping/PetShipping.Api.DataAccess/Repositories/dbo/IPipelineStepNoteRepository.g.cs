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

		POCOPipelineStepNote Get(int id);

		List<POCOPipelineStepNote> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f44fa37d6b0d875656f632b88b2c9d7e</Hash>
</Codenesium>*/