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

		Task<POCOVendor> Get(int businessEntityID);

		Task<List<POCOVendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOVendor> GetAccountNumber(string accountNumber);
	}
}

/*<Codenesium>
    <Hash>4f8c0537550a96bee267c5c3afb56fff</Hash>
</Codenesium>*/