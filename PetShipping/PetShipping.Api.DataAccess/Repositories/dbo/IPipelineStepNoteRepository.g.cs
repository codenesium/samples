using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepNoteRepository
	{
		POCOPipelineStepNote Create(ApiPipelineStepNoteModel model);

		void Update(int id,
		            ApiPipelineStepNoteModel model);

		void Delete(int id);

		POCOPipelineStepNote Get(int id);

		List<POCOPipelineStepNote> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3fa67fa973cdc4187481351e39257e41</Hash>
</Codenesium>*/