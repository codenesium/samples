using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPetRepository
	{
		Task<POCOPet> Create(ApiPetModel model);

		Task Update(int id,
		            ApiPetModel model);

		Task Delete(int id);

		Task<POCOPet> Get(int id);

		Task<List<POCOPet>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>37cb60ab9445159ec879744af4b6b495</Hash>
</Codenesium>*/