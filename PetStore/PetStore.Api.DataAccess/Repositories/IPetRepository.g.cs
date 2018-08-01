using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPetRepository
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
    <Hash>e7396896965c04c6ac2ff53294886e8f</Hash>
</Codenesium>*/