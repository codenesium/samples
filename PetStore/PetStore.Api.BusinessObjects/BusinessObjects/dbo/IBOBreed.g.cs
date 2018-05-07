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
		Task<CreateResponse<int>> Create(
			BreedModel model);

		Task<ActionResponse> Update(int id,
		                            BreedModel model);

		Task<ActionResponse> Delete(int id);

		POCOBreed Get(int id);

		List<POCOBreed> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>98c3ef2264a37cb40f0e3e2715ec5c78</Hash>
</Codenesium>*/