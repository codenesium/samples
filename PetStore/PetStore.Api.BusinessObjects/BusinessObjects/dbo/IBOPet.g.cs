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
			PetModel model);

		Task<ActionResponse> Update(int id,
		                            PetModel model);

		Task<ActionResponse> Delete(int id);

		POCOPet Get(int id);

		List<POCOPet> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>42f1b0a0888a4e58abf1522c6b2d6180</Hash>
</Codenesium>*/