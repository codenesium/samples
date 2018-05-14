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
    <Hash>0292af37ecc3ec7b1ccb6208cb4b9f76</Hash>
</Codenesium>*/