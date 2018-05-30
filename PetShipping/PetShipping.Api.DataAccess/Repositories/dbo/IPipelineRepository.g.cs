using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineRepository
	{
		Task<DTOPipeline> Create(DTOPipeline dto);

		Task Update(int id,
		            DTOPipeline dto);

		Task Delete(int id);

		Task<DTOPipeline> Get(int id);

		Task<List<DTOPipeline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a49713b4bf69590c6de51e6cf53c7d4e</Hash>
</Codenesium>*/