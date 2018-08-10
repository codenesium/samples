using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface ISaleRepository
	{
		Task<Sale> Create(Sale item);

		Task Update(Sale item);

		Task Delete(int id);

		Task<Sale> Get(int id);

		Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0);

		Task<Client> GetClient(int clientId);

		Task<Pet> GetPet(int petId);
	}
}

/*<Codenesium>
    <Hash>a21fc5da2854075d5a8f8ffc4af1916e</Hash>
</Codenesium>*/