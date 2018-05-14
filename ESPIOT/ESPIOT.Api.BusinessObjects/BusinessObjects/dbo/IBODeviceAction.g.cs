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
			ApiDeviceActionModel model);

		Task<ActionResponse> Update(int id,
		                            ApiDeviceActionModel model);

		Task<ActionResponse> Delete(int id);

		POCODeviceAction Get(int id);

		List<POCODeviceAction> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>eebf327cbd229700627349dbb6a21980</Hash>
</Codenesium>*/