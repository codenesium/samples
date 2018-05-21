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

		Task<POCODestination> Get(int id);

		Task<List<POCODestination>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0e66cb6914769dcf37ca27a67c48c388</Hash>
</Codenesium>*/