using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceRepository
	{
		int Create(DeviceModel model);

		void Update(int id,
		            DeviceModel model);

		void Delete(int id);

		POCODevice Get(int id);

		List<POCODevice> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ad30e54e38510076423f51e8ba16ad1d</Hash>
</Codenesium>*/