using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientRepository
	{
		Task<Client> Create(Client item);

		Task Update(Client item);

		Task Delete(int id);

		Task<Client> Get(int id);

		Task<List<Client>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>160307f5241e6ec9e3bb3066d1842e4f</Hash>
</Codenesium>*/