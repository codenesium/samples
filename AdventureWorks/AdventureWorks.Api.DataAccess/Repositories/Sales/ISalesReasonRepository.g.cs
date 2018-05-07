using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesReasonRepository
	{
		int Create(SalesReasonModel model);

		void Update(int salesReasonID,
		            SalesReasonModel model);

		void Delete(int salesReasonID);

		POCOSalesReason Get(int salesReasonID);

		List<POCOSalesReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>91b4c10d8026666ceebfed5f3cb7506e</Hash>
</Codenesium>*/