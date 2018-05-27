using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IBODevice
	{
		Task<CreateResponse<ApiDeviceResponseModel>> Create(
			ApiDeviceRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiDeviceRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiDeviceResponseModel> Get(int id);

		Task<List<ApiDeviceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiDeviceResponseModel> PublicId(Guid publicId);
	}
}

/*<Codenesium>
    <Hash>c7799d7e31cade2081e5d004f150c01a</Hash>
</Codenesium>*/