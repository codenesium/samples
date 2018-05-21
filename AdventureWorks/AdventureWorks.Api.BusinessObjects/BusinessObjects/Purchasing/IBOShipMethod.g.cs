using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOShipMethod
	{
		Task<CreateResponse<POCOShipMethod>> Create(
			ApiShipMethodModel model);

		Task<ActionResponse> Update(int shipMethodID,
		                            ApiShipMethodModel model);

		Task<ActionResponse> Delete(int shipMethodID);

		Task<POCOShipMethod> Get(int shipMethodID);

		Task<List<POCOShipMethod>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOShipMethod> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>4017b6513cdb503ec3ae253909995caa</Hash>
</Codenesium>*/