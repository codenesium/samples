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
		Task<CreateResponse<POCOSale>> Create(
			SaleModel model);

		Task<ActionResponse> Update(int id,
		                            SaleModel model);

		Task<ActionResponse> Delete(int id);

		POCOSale Get(int id);

		List<POCOSale> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fdb6d84508bbbd4b0e265058779eb4fb</Hash>
</Codenesium>*/