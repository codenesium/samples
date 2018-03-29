using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRoutingRepository
	{
		int Create(int productID,
		           short operationSequence,
		           short locationID,
		           DateTime scheduledStartDate,
		           DateTime scheduledEndDate,
		           Nullable<DateTime> actualStartDate,
		           Nullable<DateTime> actualEndDate,
		           Nullable<decimal> actualResourceHrs,
		           decimal plannedCost,
		           Nullable<decimal> actualCost,
		           DateTime modifiedDate);

		void Update(int workOrderID, int productID,
		            short operationSequence,
		            short locationID,
		            DateTime scheduledStartDate,
		            DateTime scheduledEndDate,
		            Nullable<DateTime> actualStartDate,
		            Nullable<DateTime> actualEndDate,
		            Nullable<decimal> actualResourceHrs,
		            decimal plannedCost,
		            Nullable<decimal> actualCost,
		            DateTime modifiedDate);

		void Delete(int workOrderID);

		void GetById(int workOrderID, Response response);

		void GetWhere(Expression<Func<EFWorkOrderRouting, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2cebc5d79c40bd19817712e875b1f9af</Hash>
</Codenesium>*/