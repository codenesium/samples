using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRoutingRepository
	{
		int Create(
			int productID,
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

		void Update(int workOrderID,
		            int productID,
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

		Response GetById(int workOrderID);

		POCOWorkOrderRouting GetByIdDirect(int workOrderID);

		Response GetWhere(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOWorkOrderRouting> GetWhereDirect(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>37ef86b081c19a332eb3eac1252a1ef2</Hash>
</Codenesium>*/