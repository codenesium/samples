using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesReasonRepository
	{
		POCOSalesReason Create(ApiSalesReasonModel model);

		void Update(int salesReasonID,
		            ApiSalesReasonModel model);

		void Delete(int salesReasonID);

		POCOSalesReason Get(int salesReasonID);

		List<POCOSalesReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9851ad53a5ec87dc2aeca2ed169fe26a</Hash>
</Codenesium>*/