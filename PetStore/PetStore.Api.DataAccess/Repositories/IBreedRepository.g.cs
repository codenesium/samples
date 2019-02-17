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

		Task<List<Pet>> PetsByBreedId(int breedId, int limit = int.MaxValue, int offset = 0);

		Task<Species> SpeciesBySpeciesId(int speciesId);
	}
}

/*<Codenesium>
    <Hash>9b3bc157f3277f82f3481a5544e5b5f1</Hash>
</Codenesium>*/