using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IBreedRepository
	{
		Task<Breed> Create(Breed item);

		Task Update(Breed item);

		Task Delete(int id);

		Task<Breed> Get(int id);

		Task<List<Breed>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Pet>> PetsByBreedId(int breedId, int limit = int.MaxValue, int offset = 0);

		Task<Species> SpeciesBySpeciesId(int speciesId);
	}
}

/*<Codenesium>
    <Hash>7093c9a948c5837f20e31478d261b226</Hash>
</Codenesium>*/