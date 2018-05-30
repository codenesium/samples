using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepRepository
	{
		Task<DTOPipelineStep> Create(DTOPipelineStep dto);

		Task Update(int id,
		            DTOPipelineStep dto);

		Task Delete(int id);

		Task<DTOPipelineStep> Get(int id);

		Task<List<DTOPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cc1e225de5179f4b5a2feedca6216d26</Hash>
</Codenesium>*/