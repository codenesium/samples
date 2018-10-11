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

		Task<Client> ClientByClientId(int clientId);

		Task<Pet> PetByPetId(int petId);
	}
}

/*<Codenesium>
    <Hash>0fe51e85d52d099286a3eeba3cea3b43</Hash>
</Codenesium>*/