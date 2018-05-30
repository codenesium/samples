using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStatusRepository
	{
		Task<DTOPipelineStepStatus> Create(DTOPipelineStepStatus dto);

		Task Update(int id,
		            DTOPipelineStepStatus dto);

		Task Delete(int id);

		Task<DTOPipelineStepStatus> Get(int id);

		Task<List<DTOPipelineStepStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e59dc0a2c9a0aeeccda706a6cd0da1b8</Hash>
</Codenesium>*/