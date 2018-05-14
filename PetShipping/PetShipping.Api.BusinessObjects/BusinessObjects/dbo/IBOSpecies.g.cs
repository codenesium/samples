using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
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
    <Hash>ea91e442a355fe7ce7f7d716162ea700</Hash>
</Codenesium>*/