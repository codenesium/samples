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
		Task<CreateResponse<POCOOtherTransport>> Create(
			ApiOtherTransportModel model);

		Task<ActionResponse> Update(int id,
		                            ApiOtherTransportModel model);

		Task<ActionResponse> Delete(int id);

		POCOOtherTransport Get(int id);

		List<POCOOtherTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1e6125b87f1cfde64040f2e30d55e060</Hash>
</Codenesium>*/