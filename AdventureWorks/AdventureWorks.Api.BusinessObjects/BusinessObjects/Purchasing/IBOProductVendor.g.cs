using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductVendor
	{
		Task<CreateResponse<int>> Create(
			ProductVendorModel model);

		Task<ActionResponse> Update(int productID,
		                            ProductVendorModel model);

		Task<ActionResponse> Delete(int productID);

		POCOProductVendor Get(int productID);

		List<POCOProductVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>10683828f508570d3150c8992d4750b9</Hash>
</Codenesium>*/