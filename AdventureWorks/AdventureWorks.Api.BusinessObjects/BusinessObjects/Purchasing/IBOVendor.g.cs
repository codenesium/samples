using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOVendor
	{
		Task<CreateResponse<int>> Create(
			VendorModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            VendorModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOVendor Get(int businessEntityID);

		List<POCOVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b8287e3a1fa5ddbd426d2fc7f793ff18</Hash>
</Codenesium>*/