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
		Task<CreateResponse<ApiOtherTransportResponseModel>> Create(
			ApiOtherTransportRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiOtherTransportRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiOtherTransportResponseModel> Get(int id);

		Task<List<ApiOtherTransportResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>73880d43deb0117015345e1f8e7bbfd1</Hash>
</Codenesium>*/