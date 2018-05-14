using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IVendorRepository
	{
		POCOVendor Create(ApiVendorModel model);

		void Update(int businessEntityID,
		            ApiVendorModel model);

		void Delete(int businessEntityID);

		POCOVendor Get(int businessEntityID);

		List<POCOVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOVendor GetAccountNumber(string accountNumber);
	}
}

/*<Codenesium>
    <Hash>4b43b8ca1e5ce2b124b76b539f66a320</Hash>
</Codenesium>*/