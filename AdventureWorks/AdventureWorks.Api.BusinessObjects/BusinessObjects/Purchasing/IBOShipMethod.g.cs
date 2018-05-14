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

		POCOShipMethod Get(int shipMethodID);

		List<POCOShipMethod> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOShipMethod GetName(string name);
	}
}

/*<Codenesium>
    <Hash>82d60fae2d115f6fc101f8539c7cab22</Hash>
</Codenesium>*/