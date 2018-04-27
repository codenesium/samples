using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
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
    <Hash>65f3d8cce835f2e94c2aed05195faca1</Hash>
</Codenesium>*/