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
			ApiSaleModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSaleModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOSale> Get(int id);

		Task<List<POCOSale>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c16f5c551db4eea6b2b618a47a81278f</Hash>
</Codenesium>*/