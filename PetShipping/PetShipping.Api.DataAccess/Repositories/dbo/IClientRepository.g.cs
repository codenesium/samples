using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientRepository
	{
		Task<DTOClient> Create(DTOClient dto);

		Task Update(int id,
		            DTOClient dto);

		Task Delete(int id);

		Task<DTOClient> Get(int id);

		Task<List<DTOClient>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f49022c0675c77e76472d57cb37f5987</Hash>
</Codenesium>*/