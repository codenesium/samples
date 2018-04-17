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

		ApiResponse GetById(int shipMethodID);

		POCOShipMethod GetByIdDirect(int shipMethodID);

		ApiResponse GetWhere(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOShipMethod> GetWhereDirect(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>56d8a80edb549e648e29843fdd28adda</Hash>
</Codenesium>*/