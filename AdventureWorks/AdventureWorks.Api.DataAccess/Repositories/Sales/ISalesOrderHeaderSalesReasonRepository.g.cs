using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderSalesReasonRepository
	{
		int Create(int salesReasonID,
		           DateTime modifiedDate);

		void Update(int salesOrderID, int salesReasonID,
		            DateTime modifiedDate);

		void Delete(int salesOrderID);

		void GetById(int salesOrderID, Response response);

		void GetWhere(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c3b480f6c39dffde4878ec2f34152d61</Hash>
</Codenesium>*/