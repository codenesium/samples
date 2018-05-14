using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOVendor
	{
		Task<CreateResponse<POCOVendor>> Create(
			ApiVendorModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiVendorModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOVendor Get(int businessEntityID);

		List<POCOVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOVendor GetAccountNumber(string accountNumber);
	}
}

/*<Codenesium>
    <Hash>abb0bd67244687c94615c0b2799ce6f1</Hash>
</Codenesium>*/