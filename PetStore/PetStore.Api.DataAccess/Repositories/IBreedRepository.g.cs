using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public partial interface IBreedRepository
	{
		Task<Breed> Create(Breed item);

		Task Update(Breed item);

		Task Delete(int id);

		Task<Breed> Get(int id);

		Task<List<Breed>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Breed>> BySpeciesId(int speciesId, int limit = int.MaxValue, int offset = 0);

		Task<Species> SpeciesBySpeciesId(int speciesId);
	}
}

/*<Codenesium>
    <Hash>989ba34bcde34ec552f2bdf3ad1aa87f</Hash>
</Codenesium>*/