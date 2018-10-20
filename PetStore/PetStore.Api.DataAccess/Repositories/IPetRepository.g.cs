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

		Task<List<Sale>> SalesByPetId(int petId, int limit = int.MaxValue, int offset = 0);

		Task<Breed> BreedByBreedId(int breedId);

		Task<Pen> PenByPenId(int penId);

		Task<Species> SpeciesBySpeciesId(int speciesId);
	}
}

/*<Codenesium>
    <Hash>c0f9ec62c2d24105316faf3c8e75cccb</Hash>
</Codenesium>*/