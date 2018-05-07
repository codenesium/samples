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
		Task<CreateResponse<int>> Create(
			DeviceModel model);

		Task<ActionResponse> Update(int id,
		                            DeviceModel model);

		Task<ActionResponse> Delete(int id);

		POCODevice Get(int id);

		List<POCODevice> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9e491ee935451d3fb4a5bb159a4fed84</Hash>
</Codenesium>*/