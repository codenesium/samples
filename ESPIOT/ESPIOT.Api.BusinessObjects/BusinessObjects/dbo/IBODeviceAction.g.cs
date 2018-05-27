using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IBODeviceAction
	{
		Task<CreateResponse<ApiDeviceActionResponseModel>> Create(
			ApiDeviceActionRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiDeviceActionRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiDeviceActionResponseModel> Get(int id);

		Task<List<ApiDeviceActionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a2f34447beb73b002312c34b2860aac1</Hash>
</Codenesium>*/