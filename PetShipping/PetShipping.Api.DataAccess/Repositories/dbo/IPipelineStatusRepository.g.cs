using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStatusRepository
	{
		Task<DTOPipelineStatus> Create(DTOPipelineStatus dto);

		Task Update(int id,
		            DTOPipelineStatus dto);

		Task Delete(int id);

		Task<DTOPipelineStatus> Get(int id);

		Task<List<DTOPipelineStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4f65d1bb5166ffd44c0a98d82aa18848</Hash>
</Codenesium>*/