using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
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
    <Hash>0d31147b5a642e37a2d8da7ed2731fb9</Hash>
</Codenesium>*/