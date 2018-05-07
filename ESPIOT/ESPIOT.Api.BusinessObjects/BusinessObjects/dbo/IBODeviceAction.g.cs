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
		Task<CreateResponse<int>> Create(
			DeviceActionModel model);

		Task<ActionResponse> Update(int id,
		                            DeviceActionModel model);

		Task<ActionResponse> Delete(int id);

		POCODeviceAction Get(int id);

		List<POCODeviceAction> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bdd117986d5cdbb15c5bbd74fa98a0c7</Hash>
</Codenesium>*/