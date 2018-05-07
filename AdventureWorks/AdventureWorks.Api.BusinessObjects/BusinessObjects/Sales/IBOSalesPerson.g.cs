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
		Task<CreateResponse<int>> Create(
			SalesPersonModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            SalesPersonModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOSalesPerson Get(int businessEntityID);

		List<POCOSalesPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3a8678e774a06153f7ca8185802bcf1d</Hash>
</Codenesium>*/