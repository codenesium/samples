using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceActionRepository
	{
		Task<DTODeviceAction> Create(DTODeviceAction dto);

		Task Update(int id,
		            DTODeviceAction dto);

		Task Delete(int id);

		Task<DTODeviceAction> Get(int id);

		Task<List<DTODeviceAction>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6a734b68bff0cdeed3d311ef2ab062e9</Hash>
</Codenesium>*/