using System;
using System.Linq.Expressions;
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

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFVendor, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>385351227ed86e25c19359b40e541b36</Hash>
</Codenesium>*/