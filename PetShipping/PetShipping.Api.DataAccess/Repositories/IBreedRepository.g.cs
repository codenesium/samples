using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IBreedRepository
	{
		Task<Breed> Create(Breed item);

		Task Update(Breed item);

		Task Delete(int id);

		Task<Breed> Get(int id);

		Task<List<Breed>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Pet>> Pets(int breedId, int limit = int.MaxValue, int offset = 0);

		Task<Species> GetSpecies(int speciesId);
	}
}

/*<Codenesium>
    <Hash>b7f1b90c3b28ffc94f457de02cec4bd6</Hash>
</Codenesium>*/