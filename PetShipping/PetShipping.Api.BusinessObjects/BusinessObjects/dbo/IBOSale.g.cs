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

		Task<POCOSale> Get(int id);

		Task<List<POCOSale>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>653e4b8805c94222c4f3fd5aade7ad8d</Hash>
</Codenesium>*/