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

		ApiResponse GetById(int businessEntityID);

		POCOVendor GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOVendor> GetWhereDirect(Expression<Func<EFVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f48f53f60bb17ac2f21c7559e3fa8795</Hash>
</Codenesium>*/