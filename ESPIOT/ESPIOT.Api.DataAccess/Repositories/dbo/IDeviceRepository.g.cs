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

		ApiResponse GetById(int id);

		POCODevice GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFDevice, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODevice> GetWhereDirect(Expression<Func<EFDevice, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8c513571bc4a38284af4f37a1abcca4e</Hash>
</Codenesium>*/