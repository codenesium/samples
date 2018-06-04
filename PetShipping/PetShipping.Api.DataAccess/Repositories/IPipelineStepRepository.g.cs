using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepRepository
	{
		Task<PipelineStep> Create(PipelineStep item);

		Task Update(PipelineStep item);

		Task Delete(int id);

		Task<PipelineStep> Get(int id);

		Task<List<PipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b973a85680f97719ca9301f101bba521</Hash>
</Codenesium>*/