using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceRepository
	{
		Task<POCODevice> Create(ApiDeviceModel model);

		Task Update(int id,
		            ApiDeviceModel model);

		Task Delete(int id);

		Task<POCODevice> Get(int id);

		Task<List<POCODevice>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCODevice> PublicId(Guid publicId);
	}
}

/*<Codenesium>
    <Hash>25d3135870cf342aad1241af75911966</Hash>
</Codenesium>*/