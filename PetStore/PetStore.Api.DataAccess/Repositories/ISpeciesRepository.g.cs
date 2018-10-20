using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public partial interface ISpeciesRepository
	{
		Task<Species> Create(Species item);

		Task Update(Species item);

		Task Delete(int id);

		Task<Species> Get(int id);

		Task<List<Species>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Pet>> PetsBySpeciesId(int speciesId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4aad0c21eb76586b94c9563c196b1a0a</Hash>
</Codenesium>*/