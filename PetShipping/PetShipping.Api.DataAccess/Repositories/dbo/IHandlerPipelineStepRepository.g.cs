using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerPipelineStepRepository
	{
		Task<DTOHandlerPipelineStep> Create(DTOHandlerPipelineStep dto);

		Task Update(int id,
		            DTOHandlerPipelineStep dto);

		Task Delete(int id);

		Task<DTOHandlerPipelineStep> Get(int id);

		Task<List<DTOHandlerPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9e895d9e56904f5877c3a492ed62fe86</Hash>
</Codenesium>*/