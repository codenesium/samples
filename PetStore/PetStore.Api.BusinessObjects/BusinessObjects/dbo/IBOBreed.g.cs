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

		Task<POCOBreed> Get(int id);

		Task<List<POCOBreed>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>55401e0151e3410e1aae334c18636c51</Hash>
</Codenesium>*/