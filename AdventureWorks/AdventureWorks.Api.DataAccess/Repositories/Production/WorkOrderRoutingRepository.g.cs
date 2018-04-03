using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractWorkOrderRoutingRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractWorkOrderRoutingRepository(ILogger logger,
		                                          ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int productID,
		                          short operationSequence,
		                          short locationID,
		                          DateTime scheduledStartDate,
		                          DateTime scheduledEndDate,
		                          Nullable<DateTime> actualStartDate,
		                          Nullable<DateTime> actualEndDate,
		                          Nullable<decimal> actualResourceHrs,
		                          decimal plannedCost,
		                          Nullable<decimal> actualCost,
		                          DateTime modifiedDate)
		{
			var record = new EFWorkOrderRouting ();

			MapPOCOToEF(0, productID,
			            operationSequence,
			            locationID,
			            scheduledStartDate,
			            scheduledEndDate,
			            actualStartDate,
			            actualEndDate,
			            actualResourceHrs,
			            plannedCost,
			            actualCost,
			            modifiedDate, record);

			this._context.Set<EFWorkOrderRouting>().Add(record);
			this._context.SaveChanges();
			return record.workOrderID;
		}

		public virtual void Update(int workOrderID, int productID,
		                           short operationSequence,
		                           short locationID,
		                           DateTime scheduledStartDate,
		                           DateTime scheduledEndDate,
		                           Nullable<DateTime> actualStartDate,
		                           Nullable<DateTime> actualEndDate,
		                           Nullable<decimal> actualResourceHrs,
		                           decimal plannedCost,
		                           Nullable<decimal> actualCost,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.workOrderID == workOrderID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",workOrderID);
			}
			else
			{
				MapPOCOToEF(workOrderID,  productID,
				            operationSequence,
				            locationID,
				            scheduledStartDate,
				            scheduledEndDate,
				            actualStartDate,
				            actualEndDate,
				            actualResourceHrs,
				            plannedCost,
				            actualCost,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int workOrderID)
		{
			var record = this.SearchLinqEF(x => x.workOrderID == workOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFWorkOrderRouting>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int workOrderID, Response response)
		{
			this.SearchLinqPOCO(x => x.workOrderID == workOrderID,response);
		}

		protected virtual List<EFWorkOrderRouting> SearchLinqEF(Expression<Func<EFWorkOrderRouting, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFWorkOrderRouting> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFWorkOrderRouting, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFWorkOrderRouting, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFWorkOrderRouting> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFWorkOrderRouting> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int workOrderID, int productID,
		                               short operationSequence,
		                               short locationID,
		                               DateTime scheduledStartDate,
		                               DateTime scheduledEndDate,
		                               Nullable<DateTime> actualStartDate,
		                               Nullable<DateTime> actualEndDate,
		                               Nullable<decimal> actualResourceHrs,
		                               decimal plannedCost,
		                               Nullable<decimal> actualCost,
		                               DateTime modifiedDate, EFWorkOrderRouting   efWorkOrderRouting)
		{
			efWorkOrderRouting.workOrderID = workOrderID;
			efWorkOrderRouting.productID = productID;
			efWorkOrderRouting.operationSequence = operationSequence;
			efWorkOrderRouting.locationID = locationID;
			efWorkOrderRouting.scheduledStartDate = scheduledStartDate;
			efWorkOrderRouting.scheduledEndDate = scheduledEndDate;
			efWorkOrderRouting.actualStartDate = actualStartDate;
			efWorkOrderRouting.actualEndDate = actualEndDate;
			efWorkOrderRouting.actualResourceHrs = actualResourceHrs;
			efWorkOrderRouting.plannedCost = plannedCost;
			efWorkOrderRouting.actualCost = actualCost;
			efWorkOrderRouting.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFWorkOrderRouting efWorkOrderRouting,Response response)
		{
			if(efWorkOrderRouting == null)
			{
				return;
			}
			response.AddWorkOrderRouting(new POCOWorkOrderRouting()
			{
				WorkOrderID = efWorkOrderRouting.workOrderID.ToInt(),
				ProductID = efWorkOrderRouting.productID.ToInt(),
				OperationSequence = efWorkOrderRouting.operationSequence,
				LocationID = efWorkOrderRouting.locationID,
				ScheduledStartDate = efWorkOrderRouting.scheduledStartDate.ToDateTime(),
				ScheduledEndDate = efWorkOrderRouting.scheduledEndDate.ToDateTime(),
				ActualStartDate = efWorkOrderRouting.actualStartDate.ToNullableDateTime(),
				ActualEndDate = efWorkOrderRouting.actualEndDate.ToNullableDateTime(),
				ActualResourceHrs = efWorkOrderRouting.actualResourceHrs.ToNullableDecimal(),
				PlannedCost = efWorkOrderRouting.plannedCost,
				ActualCost = efWorkOrderRouting.actualCost,
				ModifiedDate = efWorkOrderRouting.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>70dc7bacf17fb509511c1a5caf2d8652</Hash>
</Codenesium>*/