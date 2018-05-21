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
		Task<CreateResponse<POCODevice>> Create(
			ApiDeviceModel model);

		Task<ActionResponse> Update(int id,
		                            ApiDeviceModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCODevice> Get(int id);

		Task<List<POCODevice>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCODevice> PublicId(Guid publicId);
	}
}

/*<Codenesium>
    <Hash>72f1a893c5ca67645d47ea3b0e04e45d</Hash>
</Codenesium>*/