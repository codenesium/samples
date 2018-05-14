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
		Task<CreateResponse<POCODeviceAction>> Create(
			DeviceActionModel model);

		Task<ActionResponse> Update(int id,
		                            DeviceActionModel model);

		Task<ActionResponse> Delete(int id);

		POCODeviceAction Get(int id);

		List<POCODeviceAction> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f20395a75b9358c78f970c6612f74ecc</Hash>
</Codenesium>*/