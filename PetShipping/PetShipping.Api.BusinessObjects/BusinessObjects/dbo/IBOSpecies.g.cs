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
			ApiSpeciesModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpeciesModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOSpecies> Get(int id);

		Task<List<POCOSpecies>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>857ec3c4be1bdf0fa9cff27765de149d</Hash>
</Codenesium>*/