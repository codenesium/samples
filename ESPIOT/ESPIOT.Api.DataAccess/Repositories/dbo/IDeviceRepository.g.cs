using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceRepository
	{
		POCODevice Create(ApiDeviceModel model);

		void Update(int id,
		            ApiDeviceModel model);

		void Delete(int id);

		POCODevice Get(int id);

		List<POCODevice> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCODevice PublicId(Guid publicId);
	}
}

/*<Codenesium>
    <Hash>70ebcf83c45541530fa07fa3a746542b</Hash>
</Codenesium>*/