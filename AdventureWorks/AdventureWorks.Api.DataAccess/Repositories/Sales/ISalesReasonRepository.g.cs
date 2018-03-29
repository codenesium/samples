using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesReasonRepository
	{
		int Create(string name,
		           string reasonType,
		           DateTime modifiedDate);

		void Update(int salesReasonID, string name,
		            string reasonType,
		            DateTime modifiedDate);

		void Delete(int salesReasonID);

		void GetById(int salesReasonID, Response response);

		void GetWhere(Expression<Func<EFSalesReason, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8246f048e95db5f1a2508622b492b689</Hash>
</Codenesium>*/