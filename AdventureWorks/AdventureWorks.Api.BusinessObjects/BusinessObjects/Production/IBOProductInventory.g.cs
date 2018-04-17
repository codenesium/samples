using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductInventory
	{
		Task<CreateResponse<int>> Create(
			ProductInventoryModel model);

		Task<ActionResponse> Update(int productID,
		                            ProductInventoryModel model);

		Task<ActionResponse> Delete(int productID);

		ApiResponse GetById(int productID);

		POCOProductInventory GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductInventory> GetWhereDirect(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>75e6b8a8726099c697cf25aafd83f45a</Hash>
</Codenesium>*/