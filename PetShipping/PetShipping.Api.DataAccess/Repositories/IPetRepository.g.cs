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

		Task<Breed> GetBreed(int breedId);

		Task<Client> GetClient(int clientId);
	}
}

/*<Codenesium>
    <Hash>4ee879a1fc0c99f986eacd415f5f6308</Hash>
</Codenesium>*/