using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerPipelineStepRepository
	{
		Task<HandlerPipelineStep> Create(HandlerPipelineStep item);

		Task Update(HandlerPipelineStep item);

		Task Delete(int id);

		Task<HandlerPipelineStep> Get(int id);

		Task<List<HandlerPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c896d200b5acb641dbf6c63a01a7710c</Hash>
</Codenesium>*/