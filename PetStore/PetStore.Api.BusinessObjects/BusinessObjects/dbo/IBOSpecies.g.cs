using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOSpecies
	{
		Task<CreateResponse<POCOSpecies>> Create(
			ApiSpeciesModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpeciesModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOSpecies> Get(int id);

		Task<List<POCOSpecies>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b3e0bdf8660bf639f1b3b9a59d55a0e5</Hash>
</Codenesium>*/