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
			ApiBreedModel model);

		Task<ActionResponse> Update(int id,
		                            ApiBreedModel model);

		Task<ActionResponse> Delete(int id);

		POCOBreed Get(int id);

		List<POCOBreed> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3e2d3ec72885a165911282c231a9c42c</Hash>
</Codenesium>*/