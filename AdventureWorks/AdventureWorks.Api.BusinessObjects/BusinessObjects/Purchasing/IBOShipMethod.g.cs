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
		Task<CreateResponse<int>> Create(
			ShipMethodModel model);

		Task<ActionResponse> Update(int shipMethodID,
		                            ShipMethodModel model);

		Task<ActionResponse> Delete(int shipMethodID);

		POCOShipMethod Get(int shipMethodID);

		List<POCOShipMethod> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>798784b49c855bddda9f4c22b5a4cd17</Hash>
</Codenesium>*/