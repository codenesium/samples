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
		Task<CreateResponse<POCOSalesReason>> Create(
			ApiSalesReasonModel model);

		Task<ActionResponse> Update(int salesReasonID,
		                            ApiSalesReasonModel model);

		Task<ActionResponse> Delete(int salesReasonID);

		POCOSalesReason Get(int salesReasonID);

		List<POCOSalesReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9f86ae9a3a3b3d4653903f2782123767</Hash>
</Codenesium>*/