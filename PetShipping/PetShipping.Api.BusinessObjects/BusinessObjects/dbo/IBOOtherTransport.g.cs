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

		Task<POCOOtherTransport> Get(int id);

		Task<List<POCOOtherTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a83c189ce5cf8693c9c999c09d0fdc91</Hash>
</Codenesium>*/