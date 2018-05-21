using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IVendorRepository
	{
		Task<POCOVendor> Create(ApiVendorModel model);

		Task Update(int businessEntityID,
		            ApiVendorModel model);

		Task Delete(int businessEntityID);

		Task<POCOVendor> Get(int businessEntityID);

		Task<List<POCOVendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOVendor> GetAccountNumber(string accountNumber);
	}
}

/*<Codenesium>
    <Hash>c12b36d32a687c15f2ca24c0156bdb86</Hash>
</Codenesium>*/