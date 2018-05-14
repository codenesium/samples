using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceRepository
	{
		POCODevice Create(DeviceModel model);

		void Update(int id,
		            DeviceModel model);

		void Delete(int id);

		POCODevice Get(int id);

		List<POCODevice> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCODevice PublicId(Guid publicId);
	}
}

/*<Codenesium>
    <Hash>dd735532c9aacb996fc383ee1ebf6b90</Hash>
</Codenesium>*/