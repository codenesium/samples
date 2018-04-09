using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IVendorRepository
	{
		int Create(string accountNumber,
		           string name,
		           int creditRating,
		           bool preferredVendorStatus,
		           bool activeFlag,
		           string purchasingWebServiceURL,
		           DateTime modifiedDate);

		void Update(int businessEntityID, string accountNumber,
		            string name,
		            int creditRating,
		            bool preferredVendorStatus,
		            bool activeFlag,
		            string purchasingWebServiceURL,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOVendor GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFVendor, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOVendor> GetWhereDirect(Expression<Func<EFVendor, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5e5bf3ec2c51368bfb2b7caed36e872b</Hash>
</Codenesium>*/