using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRepository
	{
		int Create(
			int productID,
			int orderQty,
			int stockedQty,
			short scrappedQty,
			DateTime startDate,
			Nullable<DateTime> endDate,
			DateTime dueDate,
			Nullable<short> scrapReasonID,
			DateTime modifiedDate);

		void Update(int workOrderID,
		            int productID,
		            int orderQty,
		            int stockedQty,
		            short scrappedQty,
		            DateTime startDate,
		            Nullable<DateTime> endDate,
		            DateTime dueDate,
		            Nullable<short> scrapReasonID,
		            DateTime modifiedDate);

		void Delete(int workOrderID);

		Response GetById(int workOrderID);

		POCOWorkOrder GetByIdDirect(int workOrderID);

		Response GetWhere(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOWorkOrder> GetWhereDirect(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cf7676175f060cacf67e2279e5f0035d</Hash>
</Codenesium>*/