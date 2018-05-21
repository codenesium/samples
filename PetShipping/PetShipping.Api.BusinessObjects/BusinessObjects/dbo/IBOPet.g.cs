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

		Task<POCOPet> Get(int id);

		Task<List<POCOPet>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c477c6bda4f27facea26fc6c492b55f6</Hash>
</Codenesium>*/