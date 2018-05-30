using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepNoteRepository
	{
		Task<DTOPipelineStepNote> Create(DTOPipelineStepNote dto);

		Task Update(int id,
		            DTOPipelineStepNote dto);

		Task Delete(int id);

		Task<DTOPipelineStepNote> Get(int id);

		Task<List<DTOPipelineStepNote>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9923c8ba255df26b0dd1e2e0ade85562</Hash>
</Codenesium>*/