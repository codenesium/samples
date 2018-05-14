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
			OtherTransportModel model);

		Task<ActionResponse> Update(int id,
		                            OtherTransportModel model);

		Task<ActionResponse> Delete(int id);

		POCOOtherTransport Get(int id);

		List<POCOOtherTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0aa52bd83abb937d64b5af30a68dbc0c</Hash>
</Codenesium>*/