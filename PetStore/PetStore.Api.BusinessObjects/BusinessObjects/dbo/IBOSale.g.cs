using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOSale
	{
		Task<CreateResponse<int>> Create(
			SaleModel model);

		Task<ActionResponse> Update(int id,
		                            SaleModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOSale GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFSale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSale> GetWhereDirect(Expression<Func<EFSale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>53831249a1356355d404308649dcda64</Hash>
</Codenesium>*/