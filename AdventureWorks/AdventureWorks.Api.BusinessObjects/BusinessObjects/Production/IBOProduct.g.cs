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

		ApiResponse GetById(int productID);

		POCOProduct GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProduct> GetWhereDirect(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7e6a490ea73f5108a3e81290702b2cc8</Hash>
</Codenesium>*/