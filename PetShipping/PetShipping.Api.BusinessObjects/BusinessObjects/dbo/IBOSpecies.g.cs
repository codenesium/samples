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

		POCOSpecies Get(int id);

		List<POCOSpecies> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a28468256431796bfa330cf96e70cf86</Hash>
</Codenesium>*/