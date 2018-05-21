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

		Task<POCOSalesReason> Get(int salesReasonID);

		Task<List<POCOSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b27f7ad5b56ef791079c1e1af0bf8ddd</Hash>
</Codenesium>*/