using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface ISpeciesRepository
	{
		Task<Species> Create(Species item);

		Task Update(Species item);

		Task Delete(int id);

		Task<Species> Get(int id);

		Task<List<Species>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>690d156e467a11e72aa7787454992f2e</Hash>
</Codenesium>*/