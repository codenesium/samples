using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesReason
	{
		Task<CreateResponse<int>> Create(
			SalesReasonModel model);

		Task<ActionResponse> Update(int salesReasonID,
		                            SalesReasonModel model);

		Task<ActionResponse> Delete(int salesReasonID);

		POCOSalesReason Get(int salesReasonID);

		List<POCOSalesReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>58ffaaa079fc3aab358b77445cf6f8a7</Hash>
</Codenesium>*/