using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPet
	{
		Task<CreateResponse<POCOPet>> Create(
			ApiPetModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPetModel model);

		Task<ActionResponse> Delete(int id);

		POCOPet Get(int id);

		List<POCOPet> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fa8a71f9cda85893bac649a01835d804</Hash>
</Codenesium>*/