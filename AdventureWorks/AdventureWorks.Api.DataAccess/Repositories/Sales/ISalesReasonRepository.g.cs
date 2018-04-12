using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesReasonRepository
	{
		int Create(
			string name,
			string reasonType,
			DateTime modifiedDate);

		void Update(int salesReasonID,
		            string name,
		            string reasonType,
		            DateTime modifiedDate);

		void Delete(int salesReasonID);

		Response GetById(int salesReasonID);

		POCOSalesReason GetByIdDirect(int salesReasonID);

		Response GetWhere(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesReason> GetWhereDirect(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a159e9677047c431686870e329565eb5</Hash>
</Codenesium>*/