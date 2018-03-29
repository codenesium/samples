using System;
using System.Linq.Expressions;
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

		void GetById(int workOrderID, Response response);

		void GetWhere(Expression<Func<EFWorkOrder, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b3a2f5c80cd5423dd15e5cbbc3f3f60c</Hash>
</Codenesium>*/