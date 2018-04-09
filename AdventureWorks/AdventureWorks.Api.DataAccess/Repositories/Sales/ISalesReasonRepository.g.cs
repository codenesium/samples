using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int salesReasonID);

		POCOSalesReason GetByIdDirect(int salesReasonID);

		Response GetWhere(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOSalesReason> GetWhereDirect(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d0c8afae3e3f412c1e8b60be98231159</Hash>
</Codenesium>*/