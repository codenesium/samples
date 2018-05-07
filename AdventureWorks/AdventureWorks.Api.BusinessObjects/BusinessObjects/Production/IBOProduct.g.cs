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
		Task<CreateResponse<int>> Create(
			ProductModel model);

		Task<ActionResponse> Update(int productID,
		                            ProductModel model);

		Task<ActionResponse> Delete(int productID);

		POCOProduct Get(int productID);

		List<POCOProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0e476e8127bc04470b6ced5fc4b48936</Hash>
</Codenesium>*/