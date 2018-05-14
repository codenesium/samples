using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBODestination
	{
		Task<CreateResponse<POCODestination>> Create(
			ApiDestinationModel model);

		Task<ActionResponse> Update(int id,
		                            ApiDestinationModel model);

		Task<ActionResponse> Delete(int id);

		POCODestination Get(int id);

		List<POCODestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6720838fd18566ab17b10917d5c65060</Hash>
</Codenesium>*/