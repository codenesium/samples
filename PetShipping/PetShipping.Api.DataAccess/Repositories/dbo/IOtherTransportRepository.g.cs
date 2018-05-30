using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IOtherTransportRepository
	{
		Task<DTOOtherTransport> Create(DTOOtherTransport dto);

		Task Update(int id,
		            DTOOtherTransport dto);

		Task Delete(int id);

		Task<DTOOtherTransport> Get(int id);

		Task<List<DTOOtherTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cb1426caf20e50fd16ee67239a690461</Hash>
</Codenesium>*/