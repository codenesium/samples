using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IVendorRepository
	{
		int Create(
			string accountNumber,
			string name,
			int creditRating,
			bool preferredVendorStatus,
			bool activeFlag,
			string purchasingWebServiceURL,
			DateTime modifiedDate);

		void Update(int businessEntityID,
		            string accountNumber,
		            string name,
		            int creditRating,
		            bool preferredVendorStatus,
		            bool activeFlag,
		            string purchasingWebServiceURL,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOVendor GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOVendor> GetWhereDirect(Expression<Func<EFVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d214fa94967af37215092c51f02292ee</Hash>
</Codenesium>*/