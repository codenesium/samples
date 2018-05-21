using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOPet
	{
		Task<CreateResponse<POCOPet>> Create(
			ApiPetModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPetModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOPet> Get(int id);

		Task<List<POCOPet>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>78f5328dbed63bef87c4048027406596</Hash>
</Codenesium>*/