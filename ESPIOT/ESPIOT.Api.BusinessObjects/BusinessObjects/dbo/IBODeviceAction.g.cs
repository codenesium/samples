using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IBODeviceAction
	{
		Task<CreateResponse<int>> Create(
			DeviceActionModel model);

		Task<ActionResponse> Update(int id,
		                            DeviceActionModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCODeviceAction GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFDeviceAction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODeviceAction> GetWhereDirect(Expression<Func<EFDeviceAction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8d63f22b8e16771932fca91787644d59</Hash>
</Codenesium>*/