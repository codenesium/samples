using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProduct
	{
		Task<CreateResponse<POCOProduct>> Create(
			ApiProductModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductModel model);

		Task<ActionResponse> Delete(int productID);

		POCOProduct Get(int productID);

		List<POCOProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOProduct GetName(string name);

		POCOProduct GetProductNumber(string productNumber);
	}
}

/*<Codenesium>
    <Hash>9bd2a8b4af3a8504d0c30318e3bf1381</Hash>
</Codenesium>*/