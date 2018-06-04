using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface ISaleRepository
	{
		Task<Sale> Create(Sale item);

		Task Update(Sale item);

		Task Delete(int id);

		Task<Sale> Get(int id);

		Task<List<Sale>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bdad5250fc00de308b91a9e41a6df549</Hash>
</Codenesium>*/