using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>359c1528b4a3250dec115a764a86727e</Hash>
</Codenesium>*/