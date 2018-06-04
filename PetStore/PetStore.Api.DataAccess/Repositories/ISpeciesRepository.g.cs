using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>f7231d002ee4142159ee812d078ed36f</Hash>
</Codenesium>*/