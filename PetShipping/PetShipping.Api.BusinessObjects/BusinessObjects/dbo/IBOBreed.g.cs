using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOBreed
	{
		Task<CreateResponse<POCOBreed>> Create(
			ApiBreedModel model);

		Task<ActionResponse> Update(int id,
		                            ApiBreedModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOBreed> Get(int id);

		Task<List<POCOBreed>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d44b9a22fa9fef81f47675eec82f0978</Hash>
</Codenesium>*/