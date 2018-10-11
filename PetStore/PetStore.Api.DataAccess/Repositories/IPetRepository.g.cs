using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public partial interface IPetRepository
	{
		Task<Pet> Create(Pet item);

		Task Update(Pet item);

		Task Delete(int id);

		Task<Pet> Get(int id);

		Task<List<Pet>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Sale>> Sales(int petId, int limit = int.MaxValue, int offset = 0);

		Task<Breed> BreedByBreedId(int breedId);

		Task<Pen> PenByPenId(int penId);

		Task<Species> SpeciesBySpeciesId(int speciesId);
	}
}

/*<Codenesium>
    <Hash>e9bc8f3046d8a466b63257be9d1775bc</Hash>
</Codenesium>*/