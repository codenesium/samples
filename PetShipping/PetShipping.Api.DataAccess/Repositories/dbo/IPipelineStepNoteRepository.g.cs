using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepNoteRepository
	{
		POCOPipelineStepNote Create(PipelineStepNoteModel model);

		void Update(int id,
		            PipelineStepNoteModel model);

		void Delete(int id);

		POCOPipelineStepNote Get(int id);

		List<POCOPipelineStepNote> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>de9736d42ec208d2e438e24791f1ca0b</Hash>
</Codenesium>*/