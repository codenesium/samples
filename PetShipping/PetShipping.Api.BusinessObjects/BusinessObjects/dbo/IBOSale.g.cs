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
			ApiSaleModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSaleModel model);

		Task<ActionResponse> Delete(int id);

		POCOSale Get(int id);

		List<POCOSale> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9d463df45b814ffd1a1b808407bd9f53</Hash>
</Codenesium>*/