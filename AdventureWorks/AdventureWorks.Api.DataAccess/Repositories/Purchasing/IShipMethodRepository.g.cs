using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShipMethodRepository
	{
		Task<DTOShipMethod> Create(DTOShipMethod dto);

		Task Update(int shipMethodID,
		            DTOShipMethod dto);

		Task Delete(int shipMethodID);

		Task<DTOShipMethod> Get(int shipMethodID);

		Task<List<DTOShipMethod>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOShipMethod> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>930a1f885caec3f8fd4c7fcc25cae369</Hash>
</Codenesium>*/