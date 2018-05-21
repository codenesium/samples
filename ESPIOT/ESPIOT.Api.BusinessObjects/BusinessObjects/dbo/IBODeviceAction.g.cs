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

		Task<POCODeviceAction> Get(int id);

		Task<List<POCODeviceAction>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>37b165ff0e174576f48bf1b2b2caf32f</Hash>
</Codenesium>*/