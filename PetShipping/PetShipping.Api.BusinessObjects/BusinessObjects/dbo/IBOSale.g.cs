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

		POCOSale Get(int id);

		List<POCOSale> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>66361392b2c68e04dd38b1fac01a0cca</Hash>
</Codenesium>*/