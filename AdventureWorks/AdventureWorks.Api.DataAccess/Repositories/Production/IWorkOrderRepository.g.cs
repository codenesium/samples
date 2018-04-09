using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRepository
	{
		int Create(int productID,
		           int orderQty,
		           int stockedQty,
		           short scrappedQty,
		           DateTime startDate,
		           Nullable<DateTime> endDate,
		           DateTime dueDate,
		           Nullable<short> scrapReasonID,
		           DateTime modifiedDate);

		void Update(int workOrderID, int productID,
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

		Response GetWhere(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOWorkOrder> GetWhereDirect(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f754cce9fef412ad620638be027f6991</Hash>
</Codenesium>*/