using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceActionRepository
	{
		Task<POCODeviceAction> Create(ApiDeviceActionModel model);

		Task Update(int id,
		            ApiDeviceActionModel model);

		Task Delete(int id);

		Task<POCODeviceAction> Get(int id);

		Task<List<POCODeviceAction>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5a093b58c8a982223ec86432446fbfc9</Hash>
</Codenesium>*/