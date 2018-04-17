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
		Task<CreateResponse<int>> Create(
			DeviceModel model);

		Task<ActionResponse> Update(int id,
		                            DeviceModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCODevice GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFDevice, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODevice> GetWhereDirect(Expression<Func<EFDevice, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7b39dc6269cd7fd5c4367e317b889d8e</Hash>
</Codenesium>*/