using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
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

		Task<Client> ClientByClientId(int clientId);
	}
}

/*<Codenesium>
    <Hash>8fd789bf11c451d04e7903bbd83a0df5</Hash>
</Codenesium>*/