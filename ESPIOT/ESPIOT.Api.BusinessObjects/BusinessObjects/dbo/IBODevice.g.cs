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
			DeviceModel model);

		Task<ActionResponse> Update(int id,
		                            DeviceModel model);

		Task<ActionResponse> Delete(int id);

		POCODevice Get(int id);

		List<POCODevice> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCODevice PublicId(Guid publicId);
	}
}

/*<Codenesium>
    <Hash>48e79ef3367cd8086890000b72fb8ce3</Hash>
</Codenesium>*/