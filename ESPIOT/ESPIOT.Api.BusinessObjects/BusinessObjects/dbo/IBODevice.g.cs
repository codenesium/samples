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

		POCODevice Get(int id);

		List<POCODevice> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCODevice PublicId(Guid publicId);
	}
}

/*<Codenesium>
    <Hash>f6a16b191a1a8cca12f4cdf27c293c7f</Hash>
</Codenesium>*/