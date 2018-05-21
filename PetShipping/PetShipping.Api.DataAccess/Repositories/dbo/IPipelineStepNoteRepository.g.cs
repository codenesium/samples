using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepNoteRepository
	{
		Task<POCOPipelineStepNote> Create(ApiPipelineStepNoteModel model);

		Task Update(int id,
		            ApiPipelineStepNoteModel model);

		Task Delete(int id);

		Task<POCOPipelineStepNote> Get(int id);

		Task<List<POCOPipelineStepNote>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a7d2cbbec1a76f6af4f9a027abd49fe9</Hash>
</Codenesium>*/