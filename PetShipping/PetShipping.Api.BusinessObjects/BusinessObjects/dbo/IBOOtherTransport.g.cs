using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOOtherTransport
	{
		Task<CreateResponse<int>> Create(
			OtherTransportModel model);

		Task<ActionResponse> Update(int id,
		                            OtherTransportModel model);

		Task<ActionResponse> Delete(int id);

		POCOOtherTransport Get(int id);

		List<POCOOtherTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1e4e208a2ffd1290613a10d6106cd1de</Hash>
</Codenesium>*/