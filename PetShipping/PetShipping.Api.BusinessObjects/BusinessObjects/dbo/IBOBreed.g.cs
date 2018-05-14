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
			BreedModel model);

		Task<ActionResponse> Update(int id,
		                            BreedModel model);

		Task<ActionResponse> Delete(int id);

		POCOBreed Get(int id);

		List<POCOBreed> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dbb0d7296eaaeb183382b7fd318656d6</Hash>
</Codenesium>*/