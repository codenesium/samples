using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IOtherTransportService
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
    <Hash>a2d963b233df8ed7653f246b5d700eea</Hash>
</Codenesium>*/