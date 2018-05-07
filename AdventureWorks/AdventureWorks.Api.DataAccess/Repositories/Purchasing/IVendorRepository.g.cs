using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IVendorRepository
	{
		int Create(VendorModel model);

		void Update(int businessEntityID,
		            VendorModel model);

		void Delete(int businessEntityID);

		POCOVendor Get(int businessEntityID);

		List<POCOVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>438804c2060a0186207c4f6a712438e2</Hash>
</Codenesium>*/