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

		Task<Breed> GetBreed(int breedId);

		Task<Pen> GetPen(int penId);

		Task<Species> GetSpecies(int speciesId);
	}
}

/*<Codenesium>
    <Hash>3584416e85255f7ef01ccb389e9fe997</Hash>
</Codenesium>*/