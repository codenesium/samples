using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceActionRepository
	{
		POCODeviceAction Create(ApiDeviceActionModel model);

		void Update(int id,
		            ApiDeviceActionModel model);

		void Delete(int id);

		POCODeviceAction Get(int id);

		List<POCODeviceAction> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7ebb5f72ad6aa1954187af4c807a6576</Hash>
</Codenesium>*/