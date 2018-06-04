using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineRepository
	{
		Task<Pipeline> Create(Pipeline item);

		Task Update(Pipeline item);

		Task Delete(int id);

		Task<Pipeline> Get(int id);

		Task<List<Pipeline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>47e54d40b0bc7fbbbcbdaaa074bb0153</Hash>
</Codenesium>*/