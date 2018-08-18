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

		Task<List<Pet>> Pets(int breedId, int limit = int.MaxValue, int offset = 0);

		Task<Species> GetSpecies(int speciesId);
	}
}

/*<Codenesium>
    <Hash>b584060968ace8c36975e535bd0b8560</Hash>
</Codenesium>*/