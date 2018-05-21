using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IOtherTransportRepository
	{
		Task<POCOOtherTransport> Create(ApiOtherTransportModel model);

		Task Update(int id,
		            ApiOtherTransportModel model);

		Task Delete(int id);

		Task<POCOOtherTransport> Get(int id);

		Task<List<POCOOtherTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1ecff8de337a23159f45ce6fef79ab2e</Hash>
</Codenesium>*/