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
			SpeciesModel model);

		Task<ActionResponse> Update(int id,
		                            SpeciesModel model);

		Task<ActionResponse> Delete(int id);

		POCOSpecies Get(int id);

		List<POCOSpecies> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ba228e0b96011813732bb9544a7443c9</Hash>
</Codenesium>*/