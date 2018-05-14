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
			PetModel model);

		Task<ActionResponse> Update(int id,
		                            PetModel model);

		Task<ActionResponse> Delete(int id);

		POCOPet Get(int id);

		List<POCOPet> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4f8973c8a279e377931ef5c518246b39</Hash>
</Codenesium>*/