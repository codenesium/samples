using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesPerson
	{
		Task<CreateResponse<POCOSalesPerson>> Create(
			ApiSalesPersonModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiSalesPersonModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<POCOSalesPerson> Get(int businessEntityID);

		Task<List<POCOSalesPerson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6cc28c88d2f4cd5c802b2eda4f98401a</Hash>
</Codenesium>*/