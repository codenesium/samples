using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceActionRepository
	{
		int Create(DeviceActionModel model);

		void Update(int id,
		            DeviceActionModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCODeviceAction GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFDeviceAction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODeviceAction> GetWhereDirect(Expression<Func<EFDeviceAction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>79e741356d17ff9913bd2942088cdb7d</Hash>
</Codenesium>*/